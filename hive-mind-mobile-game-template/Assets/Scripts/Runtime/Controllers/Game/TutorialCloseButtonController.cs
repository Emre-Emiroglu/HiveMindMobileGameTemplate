using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.Game;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.Game;
using HiveMindMobileGameTemplate.Runtime.Views.Game;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class TutorialCloseButtonController : Controller<TutorialModel, TutorialSettings, TutorialPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public TutorialCloseButtonController(TutorialModel model, TutorialPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            Model.SetIsTutorialShowed(true);

            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}