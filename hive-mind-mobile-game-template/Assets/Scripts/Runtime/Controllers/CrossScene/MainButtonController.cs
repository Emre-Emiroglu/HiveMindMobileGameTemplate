using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class MainButtonController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus _signalBus;
        private readonly SettingsVerticalGroupController _settingsVerticalGroupController;
        #endregion
        
        #region Constructor
        public MainButtonController(SettingsModel model, SettingsView view, SignalBus signalBus,
            SettingsVerticalGroupController settingsVerticalGroupController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsVerticalGroupController = settingsVerticalGroupController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _settingsVerticalGroupController.Execute(!_settingsVerticalGroupController.IsVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}