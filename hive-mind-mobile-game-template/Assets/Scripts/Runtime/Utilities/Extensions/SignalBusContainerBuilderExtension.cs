using CodeCatGames.HMSignalBus.Runtime;
using VContainer;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions
{
    public static class SignalBusContainerBuilderExtension
    {
        #region Fields
        private static SignalBus _signalBus;
        #endregion

        #region Executes
        public static void DeclareSignal<TSignal>(this IContainerBuilder containerBuilder)
        {
            if (_signalBus != null)
                DeclareLogic<TSignal>();
            else
            {
                containerBuilder.RegisterBuildCallback(container =>
                {
                    _signalBus = container.Resolve<SignalBus>();

                    DeclareLogic<TSignal>();
                });
            }
        }
        public static void RegisterSignalBus(this IContainerBuilder containerBuilder)
        {
            containerBuilder.Register<SignalBus>(Lifetime.Singleton).AsSelf();

            containerBuilder.RegisterBuildCallback(container => _signalBus = container.Resolve<SignalBus>());
        }
        private static void DeclareLogic<TSignal>()
        {
            if (!_signalBus.HasDeclared<TSignal>())
                _signalBus.DeclareSignal<TSignal>();
        }
        #endregion
    }
}