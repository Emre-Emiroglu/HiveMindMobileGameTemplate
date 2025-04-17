using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class SettingsMediator : Mediator<SettingsView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly AudioModel _audioModel;
        private readonly HapticModel _hapticModel;
        #endregion

        #region Fields
        private bool _isVerticalGroupActive;
        #endregion

        #region Constructor
        public SettingsMediator(SettingsView view, SignalBus signalBus, AudioModel audioModel, HapticModel hapticModel) : base(view)
        {
            _signalBus = signalBus;
            _audioModel = audioModel;
            _hapticModel = hapticModel;
        }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion

        #region Core
        public override void Initialize()
        {
            _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
            _signalBus.Subscribe<SettingsButtonRefreshSignal>(OnSettingsButtonRefreshSignal);

            GetView.Button.onClick.AddListener(ButtonClicked);
            GetView.ExitButton.onClick.AddListener(ExitButtonClicked);

            foreach (KeyValuePair<SettingsTypes, Button> item in GetView.SettingsButtons)
            {
                SetupVisual(item.Key);

                item.Value.onClick.AddListener(() => SettingsButtonClicked(item.Key));
            }
        }
        public override void Dispose()
        {
            _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
            _signalBus.Unsubscribe<SettingsButtonRefreshSignal>(OnSettingsButtonRefreshSignal);

            GetView.Button.onClick.RemoveListener(ButtonClicked);
            GetView.ExitButton.onClick.RemoveListener(ExitButtonClicked);

            foreach (KeyValuePair<SettingsTypes, Button> item in GetView.SettingsButtons)
                item.Value.onClick.RemoveListener(() => SettingsButtonClicked(item.Key));
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) => SetVerticalGroupActivation(false);
        private void OnSettingsButtonRefreshSignal(SettingsButtonRefreshSignal signal) =>
            SetupVisual(signal.SettingsType);
        #endregion

        #region ButtonReceivers
        private void ButtonClicked()
        {
            SetVerticalGroupActivation(!_isVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire(new PlayHapticSignal(HapticPatterns.PresetType.LightImpact));
        }
        private void ExitButtonClicked()
        {
            SceneID currentSceneID = (SceneID)SceneManager.GetActiveScene().buildIndex;

            switch (currentSceneID)
            {
                case SceneID.Bootstrap:
                    break;
                case SceneID.MainMenu:
                    _signalBus.Fire(new AppQuitSignal());
                    break;
                case SceneID.Game:
                    _signalBus.Fire(new GameExitSignal());
                    _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
                    _signalBus.Fire(new PlayHapticSignal(HapticPatterns.PresetType.LightImpact));
                    break;
            }
        }
        private void SettingsButtonClicked(SettingsTypes settingsType)
        {
            _signalBus.Fire(new SettingsButtonPressedSignal(settingsType));

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            _signalBus.Fire(new PlayHapticSignal(HapticPatterns.PresetType.LightImpact));
        }
        #endregion

        #region Executes
        private void SetupVisual(SettingsTypes settingsType)
        {
            bool isActive = false;

            switch (settingsType)
            {
                case SettingsTypes.Music:
                    isActive = !_audioModel.IsMusicMuted;
                    break;
                case SettingsTypes.Sound:
                    isActive = !_audioModel.IsSoundMuted;
                    break;
                case SettingsTypes.Haptic:
                    isActive = !_hapticModel.IsHapticMuted;
                    break;
            }

            GetView.SettingsOnImages[settingsType].SetActive(isActive);
            GetView.SettingsOffImages[settingsType].SetActive(!isActive);
        }
        private void SetVerticalGroupActivation(bool isActive)
        {
            _isVerticalGroupActive = isActive;
            GetView.VerticalGroup.SetActive(_isVerticalGroupActive);
        }
        #endregion
    }
}
