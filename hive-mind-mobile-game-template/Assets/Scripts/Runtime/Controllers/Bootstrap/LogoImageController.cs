﻿using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Models.Bootstrap;
using HiveMindMobileGameTemplate.Runtime.Views.Bootstrap;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.Bootstrap
{
    public sealed class LogoImageController : Controller<BootstrapModel, BootstrapSettings, LogoHolderPanelView>
    {
        #region Constructor
        public LogoImageController(BootstrapModel model, LogoHolderPanelView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            View.LogoImage.sprite = Model.Settings.LogoSprite;
            View.LogoImage.preserveAspect = true;
        }
        #endregion
    }
}