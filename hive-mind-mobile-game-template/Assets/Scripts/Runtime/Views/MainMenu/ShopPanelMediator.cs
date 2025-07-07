using System;
using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class ShopPanelMediator : Mediator<MainMenuModel, MainMenuSettings, ShopPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ShopPanelActivationController _shopPanelActivationController;
        private readonly HomeButtonController _homeButtonController;
        #endregion
        
        #region Constructor
        public ShopPanelMediator(MainMenuModel model, ShopPanelView view, SignalBus signalBus,
            ShopPanelActivationController shopPanelActivationController,
            HomeButtonController homeButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _shopPanelActivationController = shopPanelActivationController;
            _homeButtonController = homeButtonController;
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
        private void OnHomeButtonClicked() => _homeButtonController.Execute();
        #endregion
    }
}