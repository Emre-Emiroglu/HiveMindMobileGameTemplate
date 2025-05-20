using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.Game
{
    public sealed class GameHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly TutorialModel _tutorialModel;
        private readonly LevelModel _levelModel;
        #endregion
        
        #region Constructor
        public GameHandler(SignalBus signalBus, TutorialModel tutorialModel, LevelModel levelModel) : base(signalBus)
        {
            _tutorialModel = tutorialModel;
            _levelModel = levelModel;
        }
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<InitializeGameSignal>(OnInitializeGameSignal);
                SignalBus.Subscribe<PlayGameSignal>(OnPlayGameSignal);
                SignalBus.Subscribe<GameOverSignal>(OnGameOverSignal);
                SignalBus.Subscribe<GameExitSignal>(OnGameExitSignal);
            }
            else
            {
                SignalBus.Unsubscribe<InitializeGameSignal>(OnInitializeGameSignal);
                SignalBus.Unsubscribe<PlayGameSignal>(OnPlayGameSignal);
                SignalBus.Unsubscribe<GameOverSignal>(OnGameOverSignal);
                SignalBus.Unsubscribe<GameExitSignal>(OnGameExitSignal);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnInitializeGameSignal(InitializeGameSignal signal) => InitializeGame();
        private void OnPlayGameSignal(PlayGameSignal signal) => PlayGame();
        private void OnGameOverSignal(GameOverSignal signal) => GameOver(signal.IsSuccess);
        private void OnGameExitSignal(GameExitSignal signal) => GameExit();
        #endregion

        #region Executes
        private void InitializeGame()
        {
            if (_tutorialModel.TutorialPersistentData.IsTutorialShowed)
                SignalBus.Fire(new PlayGameSignal());
            else
                SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.TutorialPanel));
        }
        private void PlayGame() => SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.InGamePanel));
        private void GameOver(bool isSuccess)
        {
            SignalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic,
                isSuccess ? SoundTypes.GameWin : SoundTypes.GameFail));

            SignalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.GameOverPanel));
            SignalBus.Fire(new SetupGameOverPanelSignal(isSuccess));

            _levelModel.ChangeLevelIndex(false, isSuccess ? 1 : 0);
        }
        private void GameExit() => SignalBus.Fire(new LoadSceneSignal(SceneID.MainMenu));
        #endregion
    }
}