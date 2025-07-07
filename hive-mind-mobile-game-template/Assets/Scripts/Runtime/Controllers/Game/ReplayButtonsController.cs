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
    public sealed class ReplayButtonsController : Controller<GameModel, GameSettings, GameOverPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public ReplayButtonsController(GameModel model, GameOverPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}