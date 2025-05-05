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
    public sealed class SettingsMediator : Mediator<SettingsModel, Settings, SettingsView>, IInitializable
    {
        #region ReadonlyFields
        private readonly SignalBus _signalBus;
        private readonly SettingsVisualController _settingsVisualController;
        private readonly SettingsButtonClickedController _settingsButtonClickedController;
        #endregion

        #region Constructor
        public SettingsMediator(SettingsModel model, SettingsView view, SignalBus signalBus,
            SettingsVisualController settingsVisualController,
            SettingsButtonClickedController settingsButtonClickedController) : base(model, view)
        {
            _signalBus = signalBus;
            _settingsVisualController = settingsVisualController;
            _settingsButtonClickedController = settingsButtonClickedController;
        }
        #endregion

        #region Core
        void IInitializable.Initialize() => base.Initialize();
        public override void SetSubscriptions(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _signalBus.Subscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.Button.onClick.AddListener(ButtonClicked);
                View.ExitButton.onClick.AddListener(ExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                {
                    _settingsVisualController.Execute(item.Key);

                    item.Value.onClick.AddListener(() => SettingsButtonClicked(item.Key));
                }
            }
            else
            {
                _signalBus.Unsubscribe<ChangeUIPanelSignal>(OnChangeUIPanelSignal);
                
                View.Button.onClick.RemoveListener(ButtonClicked);
                View.ExitButton.onClick.RemoveListener(ExitButtonClicked);

                foreach (KeyValuePair<SettingsTypes, Button> item in View.SettingsButtons)
                    item.Value.onClick.RemoveListener(() => SettingsButtonClicked(item.Key));
            }
        }
        #endregion

        #region SignalReceivers
        private void OnChangeUIPanelSignal(ChangeUIPanelSignal signal) =>
            _settingsVisualController.SetVerticalGroupActivation(false);
        #endregion

        #region ButtonReceivers
        private void ButtonClicked() => _settingsButtonClickedController.ButtonClicked();
        private void ExitButtonClicked() => _settingsButtonClickedController.ExitButtonClicked();
        private void SettingsButtonClicked(SettingsTypes settingsType) =>
            _settingsButtonClickedController.Execute(settingsType);
        #endregion
    }
}