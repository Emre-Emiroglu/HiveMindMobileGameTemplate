using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;
using CodeCatGames.HMModelViewController.Runtime;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class CrossSceneModel : Model<CrossSceneSettings>
    {
        #region Constructor
        public CrossSceneModel(CrossSceneSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}