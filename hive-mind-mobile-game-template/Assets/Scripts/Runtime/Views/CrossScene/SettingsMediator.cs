using System;
using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class SettingsMediator : Mediator<SettingsModel, Settings, SettingsView>, IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Fields
        private bool _isVerticalGroupActive;
        #endregion

        #region Constructor
        public SettingsMediator(SettingsModel model, SettingsView view, SignalBus signalBus) : base(model, view) =>
            _signalBus = signalBus;
        #endregion

        #region Core

        public override void Initialize()
        {
            base.Initialize();
            
            ChangeVerticalGroupActivation(false);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                View.Button.onClick.AddListener(OnMainButtonClicked);
                View.ExitButton.onClick.AddListener(OnExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                {
                    ChangeOnOffImage(item.Key);

                    item.Value.onClick.AddListener(() => OnSettingsButtonClicked(item.Key));
                }
            }
            else
            {
                View.Button.onClick.RemoveListener(OnMainButtonClicked);
                View.ExitButton.onClick.RemoveListener(OnExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                    item.Value.onClick.RemoveListener(() => OnSettingsButtonClicked(item.Key));
            }
        }
        #endregion

        #region ButtonReceivers
        private void OnMainButtonClicked() => MainButtonClicked();
        private void OnExitButtonClicked() => ExitButtonClicked();
        private void OnSettingsButtonClicked(SettingsTypes settingsType) => SettingsButtonClicked(settingsType);
        #endregion

        #region Executes
        private void ChangeVerticalGroupActivation(bool isActive)
        {
            _isVerticalGroupActive = isActive;
            View.VerticalGroup.SetActive(_isVerticalGroupActive);
        }
        private void ChangeOnOffImage(SettingsTypes settingsType)
        {
            bool isActive = false;

            switch (settingsType)
            {
                case SettingsTypes.Music:
                    isActive = !Model.IsMusicMuted;
                    break;
                case SettingsTypes.Sound:
                    isActive = !Model.IsSoundMuted;
                    break;
                case SettingsTypes.Haptic:
                    isActive = !Model.IsHapticMuted;
                    break;
            }

            View.SettingsOnImages[settingsType].SetActive(isActive);
            View.SettingsOffImages[settingsType].SetActive(!isActive);
        }
        private void SettingsButtonClicked(SettingsTypes settingsType)
        {
            switch (settingsType)
            {
                case SettingsTypes.Music:
                    Model.SetMusic(!Model.IsMusicMuted);
                    break;
                case SettingsTypes.Sound:
                    Model.SetSound(!Model.IsSoundMuted);
                    break;
                case SettingsTypes.Haptic:
                    Model.SetHaptic(!Model.IsHapticMuted);
                    break;
            }
            
            ChangeOnOffImage(settingsType);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void MainButtonClicked()
        {
            ChangeVerticalGroupActivation(!_isVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void ExitButtonClicked()
        {
            SceneID currentSceneID = (SceneID)SceneManager.GetActiveScene().buildIndex;

            switch (currentSceneID)
            {
                case SceneID.Bootstrap:
                    break;
                case SceneID.MainMenu:
                    _signalBus.Fire(new QuitApplicationSignal());
                    break;
                case SceneID.Game:
                    _signalBus.Fire(new GameExitSignal());
                    _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic,
                        SoundTypes.UIClick));
                    break;
            }
        }
        #endregion
    }
}