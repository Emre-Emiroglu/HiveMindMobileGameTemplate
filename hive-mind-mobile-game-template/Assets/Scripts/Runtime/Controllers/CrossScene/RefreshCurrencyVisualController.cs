using System.Linq;
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
            CurrencyTypes currencyType = (CurrencyTypes)parameters[0];
            bool all = parameters[1] is bool;

            if (all)
                RefreshAllCurrencyVisual();
            else
                RefreshCurrencyVisual(currencyType);
        }
        private void RefreshAllCurrencyVisual() => Model.CurrencyValues.Keys.ToList().ForEach(RefreshCurrencyVisual);
        private void RefreshCurrencyVisual(CurrencyTypes currencyType)
        {
            int value = Model.CurrencyValues[currencyType];

            View.CurrencyTexts[currencyType].SetText(TextFormatter.FormatNumber(value));
        }
        #endregion
    }
}