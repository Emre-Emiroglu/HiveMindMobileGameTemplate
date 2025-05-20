using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Temp;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene
{
    public sealed class CrossSceneHandler : SignalListener
    {
        #region ReadonlyFields
        private readonly CurrencyModel _currencyModel; 
        #endregion
        
        #region Constructor
        public CrossSceneHandler(SignalBus signalBus, CurrencyModel currencyModel) : base(signalBus) =>
            _currencyModel = currencyModel;
        #endregion

        #region Core
        protected override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                SignalBus.Subscribe<LoadSceneSignal>(OnLoadSceneSignal);
                SignalBus.Subscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
            }
            else
            {
                SignalBus.Unsubscribe<LoadSceneSignal>(OnLoadSceneSignal);
                SignalBus.Unsubscribe<ChangeCurrencySignal>(OnChangeCurrencySignal);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnLoadSceneSignal(LoadSceneSignal signal) => LoadScene(signal.SceneID);
        private void OnChangeCurrencySignal(ChangeCurrencySignal signal) =>
            ChangeCurrency(signal.CurrencyType, signal.Amount, signal.IsSet);
        #endregion

        #region Executes
        private void LoadScene(SceneID sceneID) => SceneManager.LoadScene((int)sceneID);
        private void ChangeCurrency(CurrencyTypes currencyType, int amount, bool isSet)
        {
            _currencyModel.ChangeCurrencyValue(currencyType, amount, isSet);

            SignalBus.Fire(new RefreshCurrencyVisualSignal(currencyType));
        }
        #endregion
    }
}