using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class TutorialPanelView : View
    {
        #region Fields
        [Header("Tutorial Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private Button closeButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public Button CloseButton => closeButton;
        #endregion
    }
}