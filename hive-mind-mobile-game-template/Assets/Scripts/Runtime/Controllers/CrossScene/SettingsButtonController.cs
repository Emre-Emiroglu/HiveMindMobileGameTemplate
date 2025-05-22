using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsButtonController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus _signalBus;
        private readonly SettingsButtonVisualController _settingsButtonVisualController;
        #endregion
        
        #region Constructor
        public SettingsButtonController(SettingsModel model, SettingsView view, SignalBus signalBus,
            SettingsButtonVisualController settingsButtonVisualController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsButtonVisualController = settingsButtonVisualController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SettingsTypes settingsType = (SettingsTypes) parameters[0];
            
            switch (settingsType)
            {
                case SettingsTypes.Music:
                    Model.SetMusic(!Model.SettingsPersistentData.IsMusicMuted);
                    break;
                case SettingsTypes.Sound:
                    Model.SetSound(!Model.SettingsPersistentData.IsSoundMuted);
                    break;
                case SettingsTypes.Haptic:
                    Model.SetHaptic(!Model.SettingsPersistentData.IsHapticMuted);
                    break;
            }
            
            _settingsButtonVisualController.Execute(settingsType);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}