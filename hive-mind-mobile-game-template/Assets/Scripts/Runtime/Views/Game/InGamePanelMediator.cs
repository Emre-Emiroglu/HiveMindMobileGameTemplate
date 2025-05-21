using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class InGamePanelMediator : Mediator<GameModel, GameSettings, InGamePanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly InGamePanelActivationController _inGamePanelActivationController;
        private readonly WinButtonClickedController _winButtonClickedController;
        private readonly FailButtonClickedController _failButtonClickedController;
        private readonly AddCurrencyButtonClickedController _addCurrencyButtonClickedController;
        #endregion

        #region Constructor
        public InGamePanelMediator(GameModel model, InGamePanelView view, SignalBus signalBus,
            InGamePanelActivationController inGamePanelActivationController,
            WinButtonClickedController winButtonClickedController,
            FailButtonClickedController failButtonClickedController,
            AddCurrencyButtonClickedController addCurrencyButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _inGamePanelActivationController = inGamePanelActivationController;
            _winButtonClickedController = winButtonClickedController;
            _failButtonClickedController = failButtonClickedController;
            _addCurrencyButtonClickedController = addCurrencyButtonClickedController;
        }

        #endregion

        #region Core
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.AddListener(OnWinButtonClicked);
                View.FailButton.onClick.AddListener(OnFailButtonClicked);
                View.AddCurrencyButton.onClick.AddListener(OnAddCurrencyButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.RemoveListener(OnWinButtonClicked);
                View.FailButton.onClick.RemoveListener(OnFailButtonClicked);
                View.AddCurrencyButton.onClick.RemoveListener(OnAddCurrencyButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _inGamePanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnWinButtonClicked() => _winButtonClickedController.Execute();
        private void OnFailButtonClicked() => _failButtonClickedController.Execute();
        private void OnAddCurrencyButtonClicked() => _addCurrencyButtonClickedController.Execute();
        #endregion
    }
}