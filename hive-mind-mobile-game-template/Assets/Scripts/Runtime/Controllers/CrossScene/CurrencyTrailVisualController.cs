using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class CurrencyTrailVisualController : Controller<CurrencyModel, CurrencySettings, CurrencyTrailView>
    {
        #region Constructor
        public CurrencyTrailVisualController(CurrencyModel model, CurrencyTrailView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            CurrencyTrailData data = View.CurrencyTrailData;
            
            View.transform.position = data.StartPosition;
            
            View.IconImage.sprite = Model.Settings.CurrencyIcons[data.CurrencyType];
            View.IconImage.preserveAspect = true;
            
            View.AmountText.SetText($"{data.Amount}x");
        }
        #endregion
    }
}