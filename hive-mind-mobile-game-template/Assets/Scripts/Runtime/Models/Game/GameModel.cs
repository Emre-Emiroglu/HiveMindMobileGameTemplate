using HMModelViewController.Runtime;
using HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;

namespace HiveMindMobileGameTemplate.Runtime.Models.Game
{
    public sealed class GameModel : Model<GameSettings>
    {
        #region Constructor
        public GameModel(GameSettings settings) : base(settings) { }
        #endregion

        #region Executes
        public override void LoadData() { }
        public override void SaveData() { }
        #endregion
    }
}