using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class MainButtonClickedController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region ReadonylFields
        private readonly SignalBus _signalBus;
        private readonly ChangeVerticalGroupActivityController _changeVerticalGroupActivityController;
        #endregion
        
        #region Constructor
        public MainButtonClickedController(SettingsModel model, SettingsView view, SignalBus signalBus,
            ChangeVerticalGroupActivityController changeVerticalGroupActivityController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeVerticalGroupActivityController = changeVerticalGroupActivityController;
        }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _changeVerticalGroupActivityController.Execute(
                !_changeVerticalGroupActivityController.IsVerticalGroupActive);

            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}