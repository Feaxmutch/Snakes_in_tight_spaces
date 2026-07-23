using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class SceneAutoload
{
    private const string BuildSettingsScenePath = "Assets/Scenes/BootstrapScene.unity";

    static SceneAutoload()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(BuildSettingsScenePath);
        }
    }
}
