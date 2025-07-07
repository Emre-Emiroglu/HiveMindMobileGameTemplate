using AYellowpaper.SerializedCollections;
using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using UnityEngine;
using UnityEngine.UI;

namespace HiveMindMobileGameTemplate.Runtime.Views.Game
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class GameOverPanelView : View
    {
        #region Fields
        [Header("Game Over Panel View Fields")]
        [SerializeField] private UIPanelVo uiPanelVo;
        [SerializeField] private SerializedDictionary<bool, GameObject> gameOverPanels;
        [SerializeField] private Button failReturnToMainMenuButton;
        [SerializeField] private Button successReturnToMainMenuButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextButton;
        #endregion

        #region Getters
        public UIPanelVo UIPanelVo => uiPanelVo;
        public SerializedDictionary<bool, GameObject> GameOverPanels => gameOverPanels;
        public Button FailReturnToMainMenuButton => failReturnToMainMenuButton;
        public Button SuccessReturnToMainMenuButton => successReturnToMainMenuButton;
        public Button RestartButton => restartButton;
        public Button NextButton => nextButton;
        #endregion
    }
}