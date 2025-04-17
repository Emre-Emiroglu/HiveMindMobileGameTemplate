using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.CrossScene;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.CrossScene
{
    public sealed class CrossSceneModelInstaller: Installer
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CrossSceneModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AudioModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CurrencyModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HapticModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelModel>().AsSingle().NonLazy();
        }
        #endregion
    }
}