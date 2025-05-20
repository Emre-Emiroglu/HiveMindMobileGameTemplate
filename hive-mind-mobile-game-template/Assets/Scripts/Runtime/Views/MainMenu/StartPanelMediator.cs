using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class StartPanelMediator : Mediator<MainMenuModel, MainMenuSettings, StartPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public StartPanelMediator(MainMenuModel model, StartPanelView view, SignalBus signalBus, LevelModel levelModel)
            : base(model, view)
        {
            _signalBus = signalBus;
            _levelModel = levelModel;
        }
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.PlayButton.onClick.AddListener(OnPlayButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) => ChangeUIPanel(signal.UIPanelType);
        #endregion
        
        #region ButtonReceivers
        private void OnPlayButtonClicked() => PlayButtonClicked();
        #endregion

        #region Executes
        private void ChangeUIPanel(UIPanelTypes uiPanelType)
        {
            bool isShow = uiPanelType == View.UIPanelVo.UIPanelType;

            View.PlayButton.interactable = isShow;

            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            
            if (isShow)
                SetLevelText();
        }
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            
            View.LevelText.SetText($"Level {levelNumber}");
        }
        private void PlayButtonClicked()
        {
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
            
            _signalBus.Fire(new LoadSceneSignal(SceneID.Game));
        }
        #endregion
    }
}