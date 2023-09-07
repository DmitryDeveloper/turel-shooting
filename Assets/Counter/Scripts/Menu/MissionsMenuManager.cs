using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionsMenuManager : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene(SceneIndexConstants.Mission_1);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(SceneIndexConstants.Mission_2);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(SceneIndexConstants.Mission_3);
    }


    public void GoToMainMenuButton()
    {
        SceneManager.LoadScene(SceneIndexConstants.Main_Menu);
    }
}
