using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameOverPanelHomeButtonController : Controller<GameModel, GameSettings, GameOverPanelView>
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion
        
        #region Constructor
        public GameOverPanelHomeButtonController(GameModel model, GameOverPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            _signalBus.Fire(new GameExitSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}