using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;
using CodeCatGames.HMModelViewController.Runtime;
using PrimeTween;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
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