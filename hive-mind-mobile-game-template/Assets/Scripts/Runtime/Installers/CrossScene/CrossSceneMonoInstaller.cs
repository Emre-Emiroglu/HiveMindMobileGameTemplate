using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ValueObjects.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Factories.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Handlers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using UnityEngine;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.CrossScene
{
    public sealed class CrossSceneMonoInstaller : MonoInstaller
    {
        #region Fields
        [Header("Factories Fields")]
        [SerializeField] private Transform currencyTrailParent;
        [SerializeField] private GameObject currencyTrailPrefab;
        #endregion

        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<CrossSceneModelInstaller>();
            Container.Install<CrossSceneMediationInstaller>();
            Container.Install<CrossSceneSignalInstaller>();

            Container.BindInterfacesAndSelfTo<CurrencyTrailSpawnHandler>().AsSingle().NonLazy();

            Container.BindFactory<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailFactory>()
              .FromPoolableMemoryPool<CurrencyTrailData, CurrencyTrailMediator, CurrencyTrailPool>
              (poolBinder => poolBinder
                  .WithInitialSize(5)
                  .FromSubContainerResolve()
                  .ByNewPrefabInstaller<CurrencyTrailInstaller>(currencyTrailPrefab)
                  .UnderTransform(currencyTrailParent)
              );
        }
        #endregion
    }
}
