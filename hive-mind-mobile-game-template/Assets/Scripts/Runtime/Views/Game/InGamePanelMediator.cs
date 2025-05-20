using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class InGamePanelMediator : Mediator<GameModel, GameSettings, InGamePanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly LevelModel _levelModel;
        #endregion

        #region Constructor
        public InGamePanelMediator(GameModel model, InGamePanelView view, SignalBus signalBus, LevelModel levelModel) :
            base(model, view)
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

                View.WinButton.onClick.AddListener(OnWinButtonPressed);
                View.FailButton.onClick.AddListener(OnFailButtonPressed);
                View.AddCurrencyButton.onClick.AddListener(OnAddCurrencyButtonPressed);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);

                View.WinButton.onClick.RemoveListener(OnWinButtonPressed);
                View.FailButton.onClick.RemoveListener(OnFailButtonPressed);
                View.AddCurrencyButton.onClick.RemoveListener(OnAddCurrencyButtonPressed);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) => ChangeUIPanel(signal.UIPanelType);
        #endregion

        #region ButtonReceivers
        private void OnWinButtonPressed() => WinButtonPressed();
        private void OnFailButtonPressed() => FailButtonPressed();
        private void OnAddCurrencyButtonPressed() => AddCurrencyButtonPressed();
        #endregion
        
        #region Executes
        private void ChangeUIPanel(UIPanelTypes uiPanelType)
        {
            bool isShow = uiPanelType == View.UIPanelVo.UIPanelType;
            
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            
            if (isShow)
                SetLevelText();
        }
        private void SetLevelText()
        {
            int levelNumber = _levelModel.LevelPersistentData.CurrentLevelIndex + 1;
            
            View.LevelText.SetText($"Level {levelNumber}");
        }
        private void WinButtonPressed()
        {
            _signalBus.Fire(new GameOverSignal(true));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void FailButtonPressed()
        {
            _signalBus.Fire(new GameOverSignal(false));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void AddCurrencyButtonPressed()
        {
            _signalBus.Fire(new ChangeCurrencySignal(CurrencyTypes.Coin,1,false));
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}