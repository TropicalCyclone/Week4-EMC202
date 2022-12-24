using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenUI : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("Continue", 0);
        SceneManager.LoadScene("Selection Screen");
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("Continue", 1);
        SceneManager.LoadScene("Game");
    }
}
