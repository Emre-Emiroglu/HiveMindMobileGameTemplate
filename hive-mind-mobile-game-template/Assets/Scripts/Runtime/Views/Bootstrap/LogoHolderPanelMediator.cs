using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HMModelViewController.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap
{
    public sealed class LogoHolderPanelMediator : Mediator<BootstrapModel, BootstrapSettings, LogoHolderPanelView>,
        IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly LogoImageController _logoImageController;
        private readonly LogoPanelActivationController _logoPanelActivationController;
        private readonly LogoTweenController _logoTweenController;
        #endregion
        
        #region Constructor
        public LogoHolderPanelMediator(BootstrapModel model, LogoHolderPanelView view,
            LogoImageController logoImageController, LogoPanelActivationController logoPanelActivationController,
            LogoTweenController logoTweenController) : base(model, view)
        {
            _logoImageController = logoImageController;
            _logoPanelActivationController = logoPanelActivationController;
            _logoTweenController = logoTweenController;
        }
        #endregion
        
        #region Core
        public override void Initialize()
        {
            base.Initialize();
            
            _logoImageController.Execute();
            _logoPanelActivationController.Execute();
            _logoTweenController.Execute();
        }
        public override void SetSubscriptions(bool isSubscribed) { }
        #endregion
    }
}
