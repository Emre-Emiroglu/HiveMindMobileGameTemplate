using System;
using System.Collections.Generic;
using HMModelViewController.Runtime;
using HMSignalBus.Runtime;
using HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Signals.CrossScene;
using UnityEngine.UI;
using VContainer.Unity;

namespace HiveMindMobileGameTemplate.Runtime.Views.CrossScene
{
    public sealed class SettingsMediator : Mediator<SettingsModel, Settings, SettingsView>, IInitializable, IDisposable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly SettingsVerticalGroupController _settingsVerticalGroupController;
        private readonly SettingsButtonVisualController _settingsButtonVisualController;
        private readonly SettingsButtonController _settingsButtonController;
        private readonly MainButtonController _mainButtonController;
        private readonly ExitButtonController _exitButtonController;
        #endregion
        
        #region Constructor
        public SettingsMediator(SettingsModel model, SettingsView view, SignalBus signalBus,
            SettingsVerticalGroupController settingsVerticalGroupController,
            SettingsButtonVisualController settingsButtonVisualController,
            SettingsButtonController settingsButtonController,
            MainButtonController mainButtonController,
            ExitButtonController exitButtonController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsVerticalGroupController = settingsVerticalGroupController;
            _settingsButtonVisualController = settingsButtonVisualController;
            _settingsButtonController = settingsButtonController;
            _mainButtonController = mainButtonController;
            _exitButtonController = exitButtonController;
        }
        #endregion

        #region Core
        public override void Initialize()
        {
            base.Initialize();
            
            _settingsVerticalGroupController.Execute(false);
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
                    _settingsButtonVisualController.Execute(item.Key);

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
            _settingsVerticalGroupController.Execute(false);
            
            foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                _settingsButtonVisualController.Execute(item.Key);
        }
        #endregion

        #region ButtonReceivers
        private void OnMainButtonClicked() => _mainButtonController.Execute();
        private void OnExitButtonClicked() => _exitButtonController.Execute();
        private void OnSettingsButtonClicked(SettingsTypes settingsType) =>
            _settingsButtonController.Execute(settingsType);
        #endregion
    }
}