using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Interfaces.CrossScene;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class StartPanelView: View, IUIPanel
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
