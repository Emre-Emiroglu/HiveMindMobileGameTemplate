using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LoadingScreenPanelView : View
    {
        #region Fields
        [Header("Loading Screen Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Image fillImage;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Image FillImage => fillImage;
        #endregion
    }
}