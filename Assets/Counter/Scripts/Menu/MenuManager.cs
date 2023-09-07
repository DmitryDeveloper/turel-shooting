using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    // we assign event onClick on Start button
    public void StartGameButton()
    {
        SceneManager.LoadScene(SceneIndexConstants.Missions_Menu);
    }

    public void ExitButton()
    {
        //it is actually instructions for the compiler. (lines starts with # , such lines will not builded)
        // inside unity it will compile EditorApplication.ExitPlaymode() but during buid Application.Quit()
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene(SceneIndexConstants.Settings_Menu);
    }
}
