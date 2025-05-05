using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class LogoHolderPanelController : Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoHolderPanelController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            View.LogoImage.sprite = Model.Settings.LogoSprite;
            View.LogoImage.preserveAspect = true;

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
            View.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(true);
        }
        #endregion
    }
}