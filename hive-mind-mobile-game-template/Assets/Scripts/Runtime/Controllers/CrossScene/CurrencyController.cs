using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyController : Controller<CurrencyModel,CurrencySettings, CurrencyView, CurrencyMediator>
    {

        #region Executes
        public void Execussste(ChangeCurrencySignal signal)
        {
            _currencyModel.ChangeCurrencyValue(signal.CurrencyType, signal.Amount, signal.IsSet);

            _signalBus.Fire(new RefreshCurrencyVisualSignal(signal.CurrencyType));
        }
        #endregion
    }
}
