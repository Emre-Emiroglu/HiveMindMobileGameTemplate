using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class InGamePanelView : View
    {
        #region Fields
        [Header("In Game Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Transform currencyTrailStartTransform;
        [SerializeField] private Transform currencyTrailTargetTransform;
        [SerializeField] private Button winButton;
        [SerializeField] private Button failButton;
        [SerializeField] private Button addCurrencyButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public TextMeshProUGUI LevelText => levelText;
        public Transform CurrencyTrailStartTransform => currencyTrailStartTransform;
        public Transform CurrencyTrailTargetTransform => currencyTrailTargetTransform;
        public Button WinButton => winButton;
        public Button FailButton => failButton;
        public Button AddCurrencyButton => addCurrencyButton;
        #endregion
    }
}