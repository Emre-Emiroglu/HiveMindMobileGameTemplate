using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Temp;

namespace HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene
{
    public sealed class CurrencyHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly CurrencyModel _currencyModel; 
        #endregion
        
        #region Constructor
        public CurrencyHandler(SignalBus signalBus, CurrencyModel currencyModel) : base(signalBus) =>
            _currencyModel = currencyModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
                SignalBus.Subscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
            else
                SignalBus.Unsubscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
        }
        #endregion

        #region SignalReceivers
        private void OnChangeCurrencySignal(ChangeCurrencySignal signal) =>
            ChangeCurrency(signal.CurrencyType, signal.Amount, signal.IsSet);
        #endregion

        #region Executes
        private void ChangeCurrency(CurrencyTypes currencyType, int amount, bool isSet)
        {
            _currencyModel.ChangeCurrencyValue(currencyType, amount, isSet);

            SignalBus.Fire(new RefreshCurrencyVisualSignal(currencyType));
        }
        #endregion
    }
}