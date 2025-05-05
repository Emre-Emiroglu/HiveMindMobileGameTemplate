using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Application;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsButtonClickedController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly SettingsVisualController _settingsVisualController;
        #endregion
        
        #region Consructor
        public SettingsButtonClickedController(SettingsModel model, SettingsView view, SignalBus signalBus,
            SettingsVisualController settingsVisualController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsVisualController = settingsVisualController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SettingsTypes settingsType = (SettingsTypes)parameters[0];
            
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
            
            _settingsVisualController.Execute(settingsType);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        public void ButtonClicked()
        {
            _settingsVisualController.SetVerticalGroupActivation(!_settingsVisualController.IsVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        public void ExitButtonClicked()
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