using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using HiveMindMobileGameTemplate.Runtime.Views.MainMenu;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu
{
    public sealed class ShopPanelActivationController : Controller<MainMenuModel, MainMenuSettings, ShopPanelView>
    {
        #region Constructor
        public ShopPanelActivationController(MainMenuModel model, ShopPanelView view) : base(model, view) { }
        #endregion
        
        #region Executes
        public override void Execute(params object[] parameters)
        {
            UIPanelTypes uiPanelType = (UIPanelTypes) parameters[0];

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(uiPanelType == View.UIPanelVo.UIPanelType);
        }
        #endregion
    }
}