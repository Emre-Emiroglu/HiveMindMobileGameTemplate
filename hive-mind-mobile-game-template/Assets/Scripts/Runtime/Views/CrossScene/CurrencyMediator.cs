using System;
using System.Collections.Generic;
using System.Linq;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using CodeCatGames.HMUtilities.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class CurrencyMediator : Mediator<CurrencyModel, CurrencySettings, CurrencyView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public CurrencyMediator(CurrencyModel model, CurrencyView view, SignalBus signalBus) : base(model, view) =>
            _signalBus = signalBus;
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
            
            RefreshAllCurrencyVisual();
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
            RefreshCurrencyVisual(signal.CurrencyType);
        #endregion

        #region ButtonReceivers
        private void OnButtonClicked() => ButtonClicked();
        #endregion

        #region Executes
        private void RefreshAllCurrencyVisual()
        {
            foreach (KeyValuePair<CurrencyTypes, int> modelCurrencyValue in Model.CurrencyPersistentData.CurrencyValues)
                RefreshCurrencyVisual(modelCurrencyValue.Key);
        }
        private void RefreshCurrencyVisual(CurrencyTypes currencyType)
        {
            int value = Model.CurrencyPersistentData.CurrencyValues[currencyType];

            View.CurrencyTexts[currencyType].SetText(TextFormatter.FormatNumber(value));
        }
        private void ButtonClicked()
        {
            _signalBus.Fire(new ChangeUIPanelSignal(UIPanelTypes.ShopPanel));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}