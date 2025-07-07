using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;

namespace HiveMindMobileGameTemplate.Runtime.Models.CrossScene
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