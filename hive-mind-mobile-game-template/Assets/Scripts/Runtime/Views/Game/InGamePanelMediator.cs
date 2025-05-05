using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class InGamePanelMediator : Mediator<GameModel, GameSettings, InGamePanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly InGamePanelChangeUIPanelController _changeUIPanelController;
        private readonly InGamePanelWinButtonPressedController _winButtonPressedController;
        private readonly InGamePanelFailButtonPressedController _failButtonPressedController;
        private readonly InGamePanelAddCurrencyButtonPressedController _addCurrencyButtonPressedController;
        #endregion

        #region Constructor
        public InGamePanelMediator(GameModel model, InGamePanelView view, SignalBus signalBus,
            InGamePanelChangeUIPanelController changeUIPanelController,
            InGamePanelWinButtonPressedController winButtonPressedController,
            InGamePanelFailButtonPressedController failButtonPressedController,
            InGamePanelAddCurrencyButtonPressedController addCurrencyButtonPressedController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeUIPanelController = changeUIPanelController;
            _winButtonPressedController = winButtonPressedController;
            _failButtonPressedController = failButtonPressedController;
            _addCurrencyButtonPressedController = addCurrencyButtonPressedController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.AddListener(OnWinButtonPressed);
                View.FailButton.onClick.AddListener(OnFailButtonPressed);
                View.AddCurrencyButton.onClick.AddListener(OnAddCurrencyButtonPressed);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.RemoveListener(OnWinButtonPressed);
                View.FailButton.onClick.RemoveListener(OnFailButtonPressed);
                View.AddCurrencyButton.onClick.RemoveListener(OnAddCurrencyButtonPressed);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _changeUIPanelController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnWinButtonPressed() => _winButtonPressedController.Execute();
        private void OnFailButtonPressed() => _failButtonPressedController.Execute();
        private void OnAddCurrencyButtonPressed() => _addCurrencyButtonPressedController.Execute();
        #endregion
    }
}