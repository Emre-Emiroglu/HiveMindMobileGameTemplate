using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.Game
{
    public sealed class GameModelInstaller : Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TutorialModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}
