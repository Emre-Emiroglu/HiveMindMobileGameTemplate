using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMUtilities.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class RefreshCurrencyVisualController : Controller<CurrencyModel, CurrencySettings, CurrencyView>
    {
        #region Constructor
        public RefreshCurrencyVisualController(CurrencyModel model, CurrencyView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            CurrencyTypes currencyType = (CurrencyTypes) parameters[0];
            bool all = (bool) parameters[1];

            if (all)
                foreach (KeyValuePair<CurrencyTypes, int> modelCurrencyValue in Model.CurrencyPersistentData.CurrencyValues)
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