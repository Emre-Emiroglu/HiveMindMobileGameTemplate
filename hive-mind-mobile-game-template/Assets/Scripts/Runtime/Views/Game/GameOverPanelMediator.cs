using System;
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
    public sealed class GameOverPanelMediator : Mediator<GameModel, GameSettings, GameOverPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        #endregion

        #region Constructor
        public GameOverPanelMediator(GameModel model, GameOverPanelView view, SignalBus signalBus) :
            base(model, view) => _signalBus = signalBus;
        #endregion

        #region Core
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
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) => ChangeUIPanel(signal.UIPanelType);
        private void OnSetupGameOverPanelSignal(SetupGameOverPanelSignal signal) =>
            SetupGameOverPanel(signal.IsSuccess);
        #endregion

        #region ButtonReceivers
        private void OnHomeButtonClicked() => HomeButtonClicked();
        private void OnRestartButtonClicked() => RestartButtonClicked();
        private void OnNextButtonClicked() => NextButtonClicked();
        #endregion
        
        #region Executes
        private void ChangeUIPanel(UIPanelTypes uiPanelType) =>
            View.UIPanelVo.CanvasGroup.ChangeUIPanelCanvasGroupActivation(uiPanelType == View.UIPanelVo.UIPanelType);
        private void SetupGameOverPanel(bool isSuccess)
        {
            foreach (KeyValuePair<bool, GameObject> item in View.GameOverPanels)
                item.Value.SetActive(item.Key == isSuccess);
        }
        private void HomeButtonClicked()
        {
            _signalBus.Fire(new GameExitSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void RestartButtonClicked()
        {
            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        private void NextButtonClicked()
        {
            _signalBus.Fire(new PlayGameSignal());
            _signalBus.Fire(new PlayAudioSignal(AudioTypes.Sound, MusicTypes.BackgroundMusic, SoundTypes.UIClick));
        }
        #endregion
    }
}