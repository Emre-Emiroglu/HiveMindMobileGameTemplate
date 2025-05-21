using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsButtonClickedController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus _signalBus;
        private readonly RefreshSettingsButtonVisualsController _refreshSettingsButtonVisualsController;
        #endregion
        
        #region Constructor
        public SettingsButtonClickedController(SettingsModel model, SettingsView view, SignalBus signalBus,
            RefreshSettingsButtonVisualsController refreshSettingsButtonVisualsController) : base(model, view)
        {
            _signalBus = signalBus;
            _refreshSettingsButtonVisualsController = refreshSettingsButtonVisualsController;
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
            
            _refreshSettingsButtonVisualsController.Execute(settingsType);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}