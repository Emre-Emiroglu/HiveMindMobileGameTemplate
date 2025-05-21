using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class ShopPanelMediator : Mediator<MainMenuModel, MainMenuSettings, ShopPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ShopPanelActivationController _shopPanelActivationController;
        private readonly HomeButtonClickedController _homeButtonClickedController;
        #endregion
        
        #region Constructor
        public ShopPanelMediator(MainMenuModel model, ShopPanelView view, SignalBus signalBus,
            ShopPanelActivationController shopPanelActivationController,
            HomeButtonClickedController homeButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _shopPanelActivationController = shopPanelActivationController;
            _homeButtonClickedController = homeButtonClickedController;
        }
        #endregion
        
        #region Core
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
            _shopPanelActivationController.Execute(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked() => _homeButtonClickedController.Execute();
        #endregion
    }
}