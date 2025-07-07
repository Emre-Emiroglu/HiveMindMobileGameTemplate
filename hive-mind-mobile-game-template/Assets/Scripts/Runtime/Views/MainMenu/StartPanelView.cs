using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class StartPanelView: View
    {
        #region Fields
        [Header("Start Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private Button playButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public TextMeshProUGUI LevelText => levelText;
        public Button PlayButton => playButton;
        #endregion
    }
}