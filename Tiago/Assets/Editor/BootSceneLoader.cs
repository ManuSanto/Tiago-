using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class BootSceneLoader
{
    private static string bootScenePath = "Assets/Scenes/_Boot.unity";
    private static string initialScenePath;
    private static bool isLoadingBootScene = false;

    static BootSceneLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            // Salvar a cena atualmente aberta
            Scene activeScene = SceneManager.GetActiveScene();
            initialScenePath = activeScene.path;

            // Carregar a cena de boot
            isLoadingBootScene = true;
            EditorSceneManager.LoadScene(bootScenePath, LoadSceneMode.Single);
        }
        else if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Aguardar um frame para garantir que a cena de boot foi carregada
            EditorApplication.update -= LoadInitialSceneOnPlayMode;
            EditorApplication.update += LoadInitialSceneOnPlayMode;
        }
        else if (state == PlayModeStateChange.ExitingPlayMode)
        {
            EditorApplication.update -= LoadInitialSceneOnPlayMode;
        }
    }

    private static void LoadInitialSceneOnPlayMode()
    {
        if (!isLoadingBootScene)
            return;

        isLoadingBootScene = false;
        EditorApplication.update -= LoadInitialSceneOnPlayMode;

        // Carregar a cena inicial aditivamente
        EditorSceneManager.LoadScene(initialScenePath, LoadSceneMode.Additive);

        // Descarregar a cena de boot após a cena inicial ser carregada
        Scene bootScene = SceneManager.GetSceneByPath(bootScenePath);
        if (bootScene.isLoaded)
        {
            EditorSceneManager.UnloadSceneAsync(bootScene);
        }
    }
}

