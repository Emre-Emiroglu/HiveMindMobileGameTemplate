using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
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