using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;
using PrimeTween;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class LogoTweenController : Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoTweenController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            Transform transform = View.LogoImage.transform;

            TweenSettings<float> tweenSettings = Model.Settings.LogoTweenSettings;

            Tween.Scale(transform, tweenSettings);
        }
        #endregion
    }
}