using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game
{
    public sealed class GameModel : Model<GameSettings>
    {
        #region Constants
        private const string ResourcePath = "Samples/SampleGame/Game/GameSettings";
        #endregion

        #region Constructor
        public GameModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
