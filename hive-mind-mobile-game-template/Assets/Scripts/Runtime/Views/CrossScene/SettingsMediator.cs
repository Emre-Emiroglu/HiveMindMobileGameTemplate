using System;
using System.Collections.Generic;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine.UI;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class SettingsMediator : Mediator<SettingsModel, Settings, SettingsView>, IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly ChangeVerticalGroupActivityController _changeVerticalGroupActivityController;
        private readonly RefreshSettingsButtonVisualsController _refreshSettingsButtonVisualsController;
        private readonly SettingsButtonClickedController _settingsButtonClickedController;
        private readonly MainButtonClickedController _mainButtonClickedController;
        private readonly ExitButtonClickedController _exitButtonClickedController;
        #endregion
        
        #region Constructor
        public SettingsMediator(SettingsModel model, SettingsView view, SignalBus signalBus,
            ChangeVerticalGroupActivityController changeVerticalGroupActivityController,
            RefreshSettingsButtonVisualsController refreshSettingsButtonVisualsController,
            SettingsButtonClickedController settingsButtonClickedController,
            MainButtonClickedController mainButtonClickedController,
            ExitButtonClickedController exitButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _changeVerticalGroupActivityController = changeVerticalGroupActivityController;
            _refreshSettingsButtonVisualsController = refreshSettingsButtonVisualsController;
            _settingsButtonClickedController = settingsButtonClickedController;
            _mainButtonClickedController = mainButtonClickedController;
            _exitButtonClickedController = exitButtonClickedController;
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
            
            _changeVerticalGroupActivityController.Execute(false);
        }
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.Button.onClick.AddListener(OnMainButtonClicked);
                View.ExitButton.onClick.AddListener(OnExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                {
                    _refreshSettingsButtonVisualsController.Execute(item.Key);

                    item.Value.onClick.AddListener(() => OnSettingsButtonClicked(item.Key));
                }
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.Button.onClick.RemoveListener(OnMainButtonClicked);
                View.ExitButton.onClick.RemoveListener(OnExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                    item.Value.onClick.RemoveListener(() => OnSettingsButtonClicked(item.Key));
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal)
        {
            _changeVerticalGroupActivityController.Execute(false);
            
            foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                _refreshSettingsButtonVisualsController.Execute(item.Key);
        }
        #endregion

        #region ButtonReceivers
        private void OnMainButtonClicked() => _mainButtonClickedController.Execute();
        private void OnExitButtonClicked() => _exitButtonClickedController.Execute();
        private void OnSettingsButtonClicked(SettingsTypes settingsType) =>
            _settingsButtonClickedController.Execute(settingsType);
        #endregion
    }
}