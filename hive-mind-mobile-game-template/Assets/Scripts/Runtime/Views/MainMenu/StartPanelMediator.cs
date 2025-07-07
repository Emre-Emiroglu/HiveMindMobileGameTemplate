using System;
using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Models.MainMenu;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Views.MainMenu
{
    public sealed class StartPanelMediator : Mediator<MainMenuModel, MainMenuSettings, StartPanelView>, IInitializable,
        IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly StartPanelActivationController _startPanelActivationController;
        private readonly PlayButtonController _playButtonController;
        #endregion

        #region Constructor
        public StartPanelMediator(MainMenuModel model, StartPanelView view, SignalBus signalBus,
            StartPanelActivationController startPanelActivationController,
            PlayButtonController playButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _startPanelActivationController = startPanelActivationController;
            _playButtonController = playButtonController;
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
        private void OnPlayButtonClicked() => _playButtonController.Execute();
        #endregion
    }
}