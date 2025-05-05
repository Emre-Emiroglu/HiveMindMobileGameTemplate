using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Controllers.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Data.ScriptableObjects.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Models.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Signals.Game;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Utilities.Extensions;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.CrossScene;
using CodeCatGames.HiveMindMobileGameTemplate.Runtime.Views.Game;
using CodeCatGames.HMSignalBus.Runtime;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CodeCatGames.HiveMindMobileGameTemplate.Runtime.Scopes.Game
{
    public sealed class GameScope : LifetimeScope
    {
        #region Fields
        [Header("Game Scope Fields")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private TutorialSettings tutorialSettings;
        #endregion
        
        #region Bindings
        protected override void Configure(IContainerBuilder builder)
        {
            ModelBindings(builder);
            MediationBindings(builder);
            ControllerBindings(builder);
        }
        private void ModelBindings(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameSettings).AsSelf();
            builder.RegisterInstance(tutorialSettings).AsSelf();

            builder.Register<GameModel>(Lifetime.Singleton).AsSelf();
            builder.Register<TutorialModel>(Lifetime.Singleton).AsSelf();
        }
        private void MediationBindings(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<InGamePanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<GameOverPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<TutorialPanelView>().AsSelf();
            builder.RegisterComponentInHierarchy<SettingsView>().AsSelf();

            builder.RegisterEntryPoint<InGamePanelMediator>().AsSelf();
            builder.RegisterEntryPoint<GameOverPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<TutorialPanelMediator>().AsSelf();
            builder.RegisterEntryPoint<SettingsMediator>().AsSelf();
        }
        private void ControllerBindings(IContainerBuilder builder)
        {
            builder.DeclareSignal<InitializeGameSignal>();
            builder.DeclareSignal<PlayGameSignal>();
            builder.DeclareSignal<GameOverSignal>();
            builder.DeclareSignal<GameExitSignal>();
            builder.DeclareSignal<SetupGameOverPanelSignal>();

            builder.RegisterEntryPoint<InGamePanelChangeUIPanelController>().AsSelf();
            builder.RegisterEntryPoint<InGamePanelWinButtonPressedController>().AsSelf();
            builder.RegisterEntryPoint<InGamePanelFailButtonPressedController>().AsSelf();
            builder.RegisterEntryPoint<InGamePanelAddCurrencyButtonPressedController>().AsSelf();
            builder.RegisterEntryPoint<InitializeGameController>().AsSelf();
            builder.RegisterEntryPoint<PlayGameController>().AsSelf();
            builder.RegisterEntryPoint<GameOverController>().AsSelf();
            builder.RegisterEntryPoint<GameExitController>().AsSelf();
            builder.RegisterEntryPoint<SettingsVisualController>().AsSelf();
            builder.RegisterEntryPoint<SettingsButtonClickedController>().AsSelf();
        }
        #endregion

        #region Cycle
        private void Start() => Container.Resolve<SignalBus>().Fire(new InitializeGameSignal());
        #endregion
    }
}