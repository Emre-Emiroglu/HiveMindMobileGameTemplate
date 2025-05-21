using System;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class StartPanelMediator : Mediator<MainMenuModel, MainMenuSettings, StartPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly StartPanelActivationController _startPanelActivationController;
        private readonly PlayButtonClickedController _playButtonClickedController;
        #endregion

        #region Constructor
        public StartPanelMediator(MainMenuModel model, StartPanelView view, SignalBus signalBus,
            StartPanelActivationController startPanelActivationController,
            PlayButtonClickedController playButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _startPanelActivationController = startPanelActivationController;
            _playButtonClickedController = playButtonClickedController;
        }
        #endregion

        #region Core
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
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _startPanelActivationController.Execute(signal.UIPanelType);
        #endregion
        
        #region ButtonReceivers
        private void OnPlayButtonClicked() => _playButtonClickedController.Execute();
        #endregion
    }
}