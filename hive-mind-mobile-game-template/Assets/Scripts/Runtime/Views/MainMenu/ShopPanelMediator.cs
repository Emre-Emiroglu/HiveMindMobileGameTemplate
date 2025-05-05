using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class ShopPanelMediator : Mediator<MainMenuModel, MainMenuSettings, ShopPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ShopPanelChangeUIPanelController _changeUIPanelController;
        private readonly ShopPanelHomeButtonClickedController _homeButtonClickedController;
        #endregion
        
        #region Constructor
        public ShopPanelMediator(MainMenuModel model, ShopPanelView view, SignalBus signalBus,
            ShopPanelChangeUIPanelController changeUIPanelController,
            ShopPanelHomeButtonClickedController homeButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeUIPanelController = changeUIPanelController;
            _homeButtonClickedController = homeButtonClickedController;
        }
        #endregion
        
        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.HomeButton.onClick.AddListener(OnHomeButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.HomeButton.onClick.RemoveListener(OnHomeButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _changeUIPanelController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked() => _homeButtonClickedController.Execute();
        #endregion
    }
}