using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using HiveMindMobileGameTemplate.Runtime.Views.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsButtonVisualController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region Constructor
        public SettingsButtonVisualController(SettingsModel model, SettingsView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SettingsTypes settingsType = (SettingsTypes) parameters[0];
            
            bool isActive = false;

            switch (settingsType)
            {
                case SettingsTypes.Music:
                    isActive = !Model.SettingsPersistentData.IsMusicMuted;
                    break;
                case SettingsTypes.Sound:
                    isActive = !Model.SettingsPersistentData.IsSoundMuted;
                    break;
                case SettingsTypes.Haptic:
                    isActive = !Model.SettingsPersistentData.IsHapticMuted;
                    break;
            }

            View.SettingsOnImages[settingsType].SetActive(isActive);
            View.SettingsOffImages[settingsType].SetActive(!isActive);
        }
        #endregion
    }
}