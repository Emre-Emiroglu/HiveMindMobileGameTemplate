using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class SettingsVerticalGroupController : Controller<SettingsModel, Settings, SettingsView>
    {
        #region Properities
        public bool IsVerticalGroupActive { get; private set; }
        #endregion
        
        #region Constructor
        public SettingsVerticalGroupController(SettingsModel model, SettingsView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            bool isActive = (bool) parameters[0];
            
            IsVerticalGroupActive = isActive;
            View.VerticalGroup.SetActive(IsVerticalGroupActive);
        }
        #endregion
    }
}