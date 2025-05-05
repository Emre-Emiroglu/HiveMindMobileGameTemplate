using System.Linq;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyMediator : Mediator<CurrencyModel, CurrencySettings, CurrencyView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ChangeCurrencyController _changeCurrencyController;
        private readonly RefreshCurrencyVisualController _refreshCurrencyVisualController;
        private readonly CurrencyButtonClickedController _currencyButtonClickedController;
        #endregion

        #region Constructor
        public CurrencyMediator(CurrencyModel model, CurrencyView view, SignalBus signalBus,
            ChangeCurrencyController changeCurrencyController,
            RefreshCurrencyVisualController refreshCurrencyVisualController,
            CurrencyButtonClickedController currencyButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeCurrencyController = changeCurrencyController;
            _refreshCurrencyVisualController = refreshCurrencyVisualController;
            _currencyButtonClickedController = currencyButtonClickedController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize()
        {
            base.Initialize();

            _refreshCurrencyVisualController.Execute(CurrencyTypes.Coin, true);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
                _signalBus.Subscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.AddListener(ButtonClicked));
            }
            else
            {
                _signalBus.Unsubscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
                _signalBus.Unsubscribe<RefreshCurrencyVisualSignal>(OnRefreshCurrencyVisualSignal);
                
                View.CurrencyButtons.Values.ToList().ForEach(x => x.onClick.RemoveAllListeners());
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeCurrencySignal(ChangeCurrencySignal signal) =>
            _changeCurrencyController.Execute(signal.CurrencyType, signal.Amount, signal.IsSet);
        private void OnRefreshCurrencyVisualSignal(RefreshCurrencyVisualSignal signal) =>
            _refreshCurrencyVisualController.Execute(signal.CurrencyType, false);
        #endregion

        #region ButtonReceivers
        private void ButtonClicked() => _currencyButtonClickedController.Execute();
        #endregion
    }
}