using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class ShopPanelView : View
    {
        #region Fields
        [Header("Shop Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Button homeButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Button HomeButton => homeButton;
        #endregion
    }
}