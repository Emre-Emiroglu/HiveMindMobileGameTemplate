using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMModelViewController.Runtime;
using PrimeTween;
using UnityEngine;
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
        void IInitializable.Initialize()
        {
            base.Initialize();
            
            SetLogoImage();
            Show();
            PlayLogoTween();
        }
        public override void SetSubscriptions(bool isSubscribed) { }
        #endregion

        #region Executes
        private void SetLogoImage()
        {
            View.LogoImage.sprite = Model.Settings.LogoSprite;
            View.LogoImage.preserveAspect = true;
        }
        private void Show() => View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(true);
        private void PlayLogoTween()
        {
            Transform transform = View.LogoImage.transform;

            TweenSettings<float> tweenSettings = Model.Settings.LogoTweenSettings;

            Tween.Scale(transform, tweenSettings);
        }
        #endregion
    }
}
