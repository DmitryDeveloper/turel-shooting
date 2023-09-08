using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionMenuManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(SceneIndexConstants.Missions_Menu);
    }
}
