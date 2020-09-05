using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using UnityEngine;

public class OpenAndStartScenesOnEditor
{
    static string dataPath = Application.dataPath;

    //START SCENES
    [MenuItem("Tools/Start Game")]
    public static void StartGame() =>                           StartGame("Levels/MainLevel");

    //OPEN SCENES
    [MenuItem("Tools/Open Scene/Main")]
    public static void OpenMainScene() =>                 OpenScene("Levels/MainLevel");
    [MenuItem("Tools/Open Scene/Test Scene")]
    public static void OpenTestSceneScene() =>                 OpenScene("TestScene");

    //FUNCTIONS
    private static bool OpenScene(string scene)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {            
            EditorSceneManager.OpenScene("Assets/Scenes/" + scene + ".unity");
            return true;
        }
        else
            return false;
    }
    public static void StartGame(string name)
    {
        if(OpenScene(name))
            EditorApplication.isPlaying = true;
    }
}
