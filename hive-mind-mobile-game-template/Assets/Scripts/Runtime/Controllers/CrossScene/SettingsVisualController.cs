using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Enums.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsVisualController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region Properities
        public bool IsVerticalGroupActive { get; private set; }
        #endregion
        
        #region Constructor
        public SettingsVisualController(SettingsModel model, SettingsView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            SettingsTypes settingsType = (SettingsTypes)parameters[0];
            
            bool isActive = false;

            switch (settingsType)
            {
                case SettingsTypes.Music:
                    isActive = !Model.IsMusicMuted;
                    break;
                case SettingsTypes.Sound:
                    isActive = !Model.IsSoundMuted;
                    break;
                case SettingsTypes.Haptic:
                    isActive = !Model.IsHapticMuted;
                    break;
            }

            View.SettingsOnImages[settingsType].SetActive(isActive);
            View.SettingsOffImages[settingsType].SetActive(!isActive);
        }
        public void SetVerticalGroupActivation(bool isActive)
        {
            IsVerticalGroupActive = isActive;
            View.VerticalGroup.SetActive(IsVerticalGroupActive);
        }
        #endregion
    }
}