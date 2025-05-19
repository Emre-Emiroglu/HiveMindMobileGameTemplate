using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions
{
    public static class UIExtensions
    {
        #region UIPanel
        public static void ChangeUIPanelCanvasGroupActivation(this CanvasGroup canvasGroup, bool isActive)
        {
            if (!canvasGroup)
                return;
            
            canvasGroup.alpha = isActive ? 1 : 0;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }
        #endregion
    }
}