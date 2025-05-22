using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
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