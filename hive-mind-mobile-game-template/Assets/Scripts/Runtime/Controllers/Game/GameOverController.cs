using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game
{
    public sealed class GameOverController : SignalListener
    {
        private readonly LevelModel _levelModel;

        public GameOverController(SignalBus signalBus, LevelModel levelModel) : base(signalBus)
        {
            _levelModel = levelModel;
        }

        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
            }
            else
            {
                SignalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
                
            }
        }

        private void OnGameOverSignal(GameOverSignal signal)
        {
            SignalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic,
                signal.IsSuccess ? SoundTypes.GameWin : SoundTypes.GameFail));

            SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.GameOverPanel));
            SignalBus.Fire(new SetupGameOverPanelSignal(signal.IsSuccess));

            _levelModel.UpdateCurrentLevelIndex(false, signal.IsSuccess ? 1 : 0);
        }
    }
}