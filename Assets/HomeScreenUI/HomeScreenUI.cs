using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenUI : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Selection Screen");
    }
}
