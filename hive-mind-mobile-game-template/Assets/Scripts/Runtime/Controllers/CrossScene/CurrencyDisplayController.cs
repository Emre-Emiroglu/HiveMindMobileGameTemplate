using System.Collections.Generic;
using HMModelViewController.Runtime;
using HMUtilities.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyDisplayController : Controller<CurrencyModel, CurrencySettings, CurrencyView>
    {
        #region Constructor
        public CurrencyDisplayController(CurrencyModel model, CurrencyView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            CurrencyTypes currencyType = (CurrencyTypes) parameters[0];
            bool all = (bool) parameters[1];

            if (all)
                foreach (KeyValuePair<CurrencyTypes, int> modelCurrencyValue in Model.CurrencyPersistentData
                             .CurrencyValues)
                    RefreshCurrencyVisual(modelCurrencyValue.Key);
            else
                RefreshCurrencyVisual(currencyType);
        }
        private void RefreshCurrencyVisual(CurrencyTypes currencyType)
        {
            int value = Model.CurrencyPersistentData.CurrencyValues[currencyType];

            View.CurrencyTexts[currencyType].SetText(TextFormatter.FormatNumber(value));
        }
        #endregion
    }
}