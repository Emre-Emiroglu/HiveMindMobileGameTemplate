using System;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using UnityEngine;

namespace HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene
{
    [Serializable]
    public struct UIPanelVo
    {
        #region Fields
        [Header("UI Panel VO Fields")]
        [SerializeField] private UIPanelTypes uiPanelType;
        [SerializeField] private CanvasGroup canvasGroup;
        #endregion

        #region Getters
        public readonly UIPanelTypes UIPanelType => uiPanelType;
        public readonly CanvasGroup CanvasGroup => canvasGroup;
        #endregion
    }
}
