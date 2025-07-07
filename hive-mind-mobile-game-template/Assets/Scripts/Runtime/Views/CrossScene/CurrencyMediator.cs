using System;
using System.Linq;
using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyMediator : Mediator<CurrencyModel, CurrencySettings, CurrencyView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly CurrencyDisplayController _currencyDisplayController;
        private readonly CurrencyButtonController _currencyButtonController;
        #endregion

        #region Constructor
        public CurrencyMediator(CurrencyModel model, CurrencyView view, SignalBus signalBus,
            CurrencyDisplayController currencyDisplayController,
            CurrencyButtonController currencyButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _currencyDisplayController = currencyDisplayController;
            _currencyButtonController = currencyButtonController;
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();

            _currencyDisplayController.Execute(CurrencyTypes.Coin, true);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.AddListener(OnButtonClicked));
            }
            else
            {
                _signalBus.Unsubscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.RemoveAllListeners());
            }
        }
        #endregion

        #region SignalReceivers
        private void OnRefreshCurrencyVisualSignal(RefreshCurrencyVisualSignal signal) =>
            _currencyDisplayController.Execute(signal.CurrencyType, false);
        #endregion

        #region ButtonReceivers
        private void OnButtonClicked() => _currencyButtonController.Execute();
        #endregion
    }
}