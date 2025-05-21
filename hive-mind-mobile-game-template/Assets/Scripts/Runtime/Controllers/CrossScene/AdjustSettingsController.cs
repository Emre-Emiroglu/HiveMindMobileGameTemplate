using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene
{
    public sealed class AdjustSettingsController : Controller<SettingsModel, Settings, AudioView>
    {
        #region Constructor
        public AdjustSettingsController(SettingsModel model, AudioView view) : base(model, view) { }
        #endregion

        #region Executes
        public override void Execute(params object[] parameters)
        {
            Model.SetMusic(Model.SettingsPersistentData.IsMusicMuted);
            Model.SetSound(Model.SettingsPersistentData.IsSoundMuted);
            Model.SetHaptic(Model.SettingsPersistentData.IsHapticMuted);
        }
        #endregion
    }
}