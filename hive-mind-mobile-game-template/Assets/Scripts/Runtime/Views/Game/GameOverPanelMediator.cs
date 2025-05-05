using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game
{
    public sealed class GameOverPanelMediator : Mediator<GameModel, GameSettings, GameOverPanelView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public GameOverPanelMediator(GameModel model, GameOverPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                _signalBus.Subscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                View.FailHomeButton.onClick.AddListener(OnHomeButtonClicked);
                View.SuccessHomeButton.onClick.AddListener(OnHomeButtonClicked);
                View.RestartButton.onClick.AddListener(OnRestartButtonClicked);
                View.NextButton.onClick.AddListener(OnNextButtonClicked);
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                _signalBus.Unsubscribe<SetupGameOverPanelSignal>(OnSetupGameOverPanelSignal);

                View.FailHomeButton.onClick.RemoveListener(OnHomeButtonClicked);
                View.SuccessHomeButton.onClick.RemoveListener(OnHomeButtonClicked);
                View.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
                View.NextButton.onClick.RemoveListener(OnNextButtonClicked);
            }
        }
        #endregion
        
        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            bool isShow = signal.UIPanelType == View.UIPanelVo.UIPanelType;
            
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(isShow);
            View.UIPanelVo.PlayableDirector.ChangeUIPanelTimelineActivation(isShow);
        }
        private void OnSetupGameOverPanelSignal(SetupGameOverPanelSignal signal)
        {
            foreach (KeyValuePair<bool, GameObject> item in View.GameOverPanels)
            {
                bool isActive = item.Key == signal.IsSuccess;
                item.Value.SetActive(isActive);
            }
        }
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked()
        {
            _signalBus.Fire(new GameExitSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void OnRestartButtonClicked()
        {
            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void OnNextButtonClicked()
        {
            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}