using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class GameOverPanelMediator : Mediator<GameModel, GameSettings, GameOverPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly GameOverPanelActivationController _gameOverPanelActivationController;
        private readonly SetupGameOverPanelController _setupGameOverPanelController;
        private readonly ReturnToMainMenuButtonClickedController _returnToMainMenuButtonClickedController;
        private readonly ReplayButtonsController _replayButtonsController;
        #endregion

        #region Constructor
        public GameOverPanelMediator(GameModel model, GameOverPanelView view, SignalBus signalBus,
            GameOverPanelActivationController gameOverPanelActivationController,
            SetupGameOverPanelController setupGameOverPanelController,
            ReturnToMainMenuButtonClickedController returnToMainMenuButtonClickedController,
            ReplayButtonsController replayButtonsController) : base(model, view)
        {
            _signalBus = signalBus;
            _gameOverPanelActivationController = gameOverPanelActivationController;
            _setupGameOverPanelController = setupGameOverPanelController;
            _returnToMainMenuButtonClickedController = returnToMainMenuButtonClickedController;
            _replayButtonsController = replayButtonsController;
        }
        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                _signalBus.Subscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                View.FailReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
                View.SuccessReturnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
                View.RestartButton.onClick.AddListener(OnRestartButtonClicked);
                View.NextButton.onClick.AddListener(OnNextButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                _signalBus.Unsubscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                View.FailReturnToMainMenuButton.onClick.RemoveListener(OnReturnToMainMenuButtonClicked);
                View.SuccessReturnToMainMenuButton.onClick.RemoveListener(OnReturnToMainMenuButtonClicked);
                View.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
                View.NextButton.onClick.RemoveListener(OnNextButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _gameOverPanelActivationController.Execute(signal.UIPanelType);
        private void OnSetupGameOverPanelSignal(SetupGameOverPanelSignal signal) =>
            _setupGameOverPanelController.Execute(signal.IsSuccess);
        #endregion

        #region ButtonReceivers
        private void OnReturnToMainMenuButtonClicked() => _returnToMainMenuButtonClickedController.Execute();
        private void OnRestartButtonClicked() => _replayButtonsController.Execute();
        private void OnNextButtonClicked() => _replayButtonsController.Execute();
        #endregion
    }
}