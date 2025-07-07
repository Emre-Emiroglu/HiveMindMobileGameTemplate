using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class LogoPanelActivationController :
        Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoPanelActivationController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters) =>
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
        #endregion
    }
}