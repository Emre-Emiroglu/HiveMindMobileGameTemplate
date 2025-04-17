using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMModelViewController.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap
{
    public sealed class LogoHolderPanelMediator : Mediator<BootstrapModel, BootstrapSettings, LogoHolderPanelView>,
        IInitializable
    {
        #region Constructor
        public LogoHolderPanelMediator(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion
        
        #region Core
        public new void Initialize()
        {
            base.Initialize();
        
            View.LogoImage.sprite = Model.Settings.LogoSprite;
            View.LogoImage.preserveAspect = true;

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
            View.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(true);
        }
        public override void SetSubscriptions(bool isSubscribed) { }
        #endregion
    }
}
