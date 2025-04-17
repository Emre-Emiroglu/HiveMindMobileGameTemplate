using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Interfaces.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Bootstrap
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LogoHolderPanelView : View, IUIPanel
    {
        #region Fields
        [Header("Logo Holder Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Image logoImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Image LogoImage => logoImage;
        #endregion
    }
}
