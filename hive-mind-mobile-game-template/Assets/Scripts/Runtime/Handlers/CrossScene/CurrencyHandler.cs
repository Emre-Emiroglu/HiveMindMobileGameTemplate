using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene
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