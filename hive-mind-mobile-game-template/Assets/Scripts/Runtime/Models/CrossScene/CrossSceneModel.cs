using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.CrossScene;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene
{
    public sealed class CrossSceneModel : Model<CrossSceneSettings>
    {
        #region Constants
        private const string ResourcePath = "Samples/SampleGame/CrossScene/CrossSceneSettings";
        #endregion

        #region Constructor
        public CrossSceneModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
