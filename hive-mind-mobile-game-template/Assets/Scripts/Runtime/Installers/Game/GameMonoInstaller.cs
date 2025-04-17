using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Installers.Game
{
    public sealed class GameMonoInstaller : MonoInstaller
    {
        #region Bindings
        public override void InstallBindings()
        {
            Container.Install<GameModelInstaller>();
            Container.Install<GameMediationInstaller>();
            Container.Install<GameSignalInstaller>();
        }
        #endregion

        #region Cycle
        public override void Start() => Container.Resolve<SignalBus>().Fire(new InitializeGameSignal());
        #endregion
    }
}
