using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.MainMenu;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.MainMenu
{
    public sealed class MainMenuModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings() =>
            Container.BindInterfacesAndSelfTo<MainMenuModel>().AsSingle().NonLazy();
        #endregion
    }
}
