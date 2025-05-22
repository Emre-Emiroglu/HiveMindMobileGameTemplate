using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace CodeCatGames.HiveMindMobileGameTemplate.Editor
{
    [InitializeOnLoad]
    public sealed class StartupSceneLoader
    {
        #region Constants
        private const string PreviousSceneKey = "PreviousScene";
        private const string ShouldLoadStartupSceneKey = "LoadStartupScene";
        private const string LoadStartupSceneOnPlay =
            "HiveMindMobileGameTemplate/StartupSceneLoader/Load Startup Scene On Play";
        private const string DontLoadStartupSceneOnPlay =
            "HiveMindMobileGameTemplate/StartupSceneLoader/Don't Load Startup Scene On Play";
        #endregion

        #region Fields
        private static bool _restartingToSwitchedScene;
        #endregion

        #region Getters
        private static string StartupScene => EditorBuildSettings.scenes[0].path;
        #endregion

        #region Props
        private static string PreviousScene
        {
            get => EditorPrefs.GetString(PreviousSceneKey);
            set => EditorPrefs.SetString(PreviousSceneKey, value);
        }
        private static bool ShouldLoadStartupScene
        {
            get
            {
                if (!EditorPrefs.HasKey(ShouldLoadStartupSceneKey))
                    EditorPrefs.SetBool(ShouldLoadStartupSceneKey, true);

                return EditorPrefs.GetBool(ShouldLoadStartupSceneKey);
            }

            set => EditorPrefs.SetBool(ShouldLoadStartupSceneKey, value);
        }
        #endregion

        #region Constructor
        static StartupSceneLoader() =>
            EditorApplication.playModeStateChanged += EditorApplicationOnPlayModeStateChanged;
        #endregion

        #region MenuItems
        [MenuItem(LoadStartupSceneOnPlay, true)]
        private static bool ShowLoadStartupSceneOnPlay() => !ShouldLoadStartupScene;
        [MenuItem(LoadStartupSceneOnPlay)]
        private static void EnableLoadStartupSceneOnPlay() => ShouldLoadStartupScene = true;
        [MenuItem(DontLoadStartupSceneOnPlay, true)]
        private static bool ShowDoNotLoadStartupSceneOnPlay() => ShouldLoadStartupScene;
        [MenuItem(DontLoadStartupSceneOnPlay)]
        private static void DisableDoNotLoadBootstrapSceneOnPlay() => ShouldLoadStartupScene = false;
        #endregion

        #region Executes
        private static void EditorApplicationOnPlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (!ShouldLoadStartupScene)
                return;

            if (_restartingToSwitchedScene)
            {
                if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
                    _restartingToSwitchedScene = false;
                
                return;
            }

            switch (playModeStateChange)
            {
                case PlayModeStateChange.ExitingEditMode:
                {
                    PreviousScene = SceneManager.GetActiveScene().path;

                    if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    {
                        if (!string.IsNullOrEmpty(StartupScene) && System.Array.Exists(EditorBuildSettings.scenes,
                                scene => scene.path == StartupScene)) 
                        {
                            Scene activeScene = SceneManager.GetActiveScene();

                            _restartingToSwitchedScene = activeScene.path == string.Empty ||
                                                         !StartupScene.Contains(activeScene.path);

                            if (_restartingToSwitchedScene)
                            {
                                EditorApplication.isPlaying = false;

                                EditorSceneManager.OpenScene(StartupScene);

                                EditorApplication.isPlaying = true;
                            }
                        }
                    }
                    else
                        EditorApplication.isPlaying = false;

                    break;
                }
                case PlayModeStateChange.EnteredEditMode:
                {
                    if (!string.IsNullOrEmpty(PreviousScene))
                        EditorSceneManager.OpenScene(PreviousScene);
                    break;
                }
            }
        }
        #endregion
    }
}
