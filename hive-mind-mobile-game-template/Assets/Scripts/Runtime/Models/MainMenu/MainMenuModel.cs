using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;

namespace HiveMindMobileGameTemplate.Runtime.Models.MainMenu
{
    public sealed class MainMenuModel : Model<MainMenuSettings>
    {
        #region Constructor
        public MainMenuModel(MainMenuSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}