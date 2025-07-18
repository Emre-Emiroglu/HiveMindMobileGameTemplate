using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.Bootstrap
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LogoHolderPanelView : View
    {
        #region Fields
        [Header("Bootstrap Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Image logoImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Image LogoImage => logoImage;
        #endregion
    }
}
