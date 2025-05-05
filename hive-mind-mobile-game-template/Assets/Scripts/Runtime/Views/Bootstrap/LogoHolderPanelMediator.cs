using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HMModelViewController.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap
{
    public sealed class LogoHolderPanelMediator : Mediator<BootstrapModel, BootstrapSettings, LogoHolderPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly LogoHolderPanelController _controller;
        #endregion
        
        #region Constructor
        public LogoHolderPanelMediator(BootstrapModel model, LogoHolderPanelView view,
            LogoHolderPanelController controller) : base(model, view) => _controller = controller;
        #endregion
        
        #region Core
        void IInitializable.Initialize()
        {
            base.Initialize();

            _controller.Execute();
        }
        public override void SetSubscriptions(bool isSubscribed) { }
        #endregion
    }
}
