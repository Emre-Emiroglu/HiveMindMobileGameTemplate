using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.MainMenu;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.MainMenu;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.MainMenu
{
    public sealed class MainMenuSignalInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.DeclareSignal<InitializeMainMenuSignal>();

            Container.BindInterfacesAndSelfTo<InitializeMainMenuCommand>().AsSingle().NonLazy();

            Container.BindSignal<InitializeMainMenuSignal>().ToMethod<InitializeMainMenuCommand>((x, s) => x.Execute(s))
                .FromResolve();
        }
        #endregion
    }
}
