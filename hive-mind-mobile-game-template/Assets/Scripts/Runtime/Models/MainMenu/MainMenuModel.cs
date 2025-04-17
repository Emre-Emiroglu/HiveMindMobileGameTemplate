using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.MainMenu;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu
{
    public sealed class MainMenuModel : Model<MainMenuSettings>
    {
        #region Constants
        private const string ResourcePath = "Samples/SampleGame/MainMenu/MainMenuSettings";
        #endregion

        #region Constructor
        public MainMenuModel() : base(ResourcePath) { }
        #endregion

        #region PostConstruct
        public override void PostConstruct() { }
        #endregion
    }
}
