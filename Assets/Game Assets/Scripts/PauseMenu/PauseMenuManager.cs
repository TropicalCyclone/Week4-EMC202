using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                isPaused = true;
                PauseMenu.gameObject.SetActive(true);
            }
            else
            {
                HidePauseScreen();
            }
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Selection Screen");
    }

    public void HidePauseScreen()
    {
        isPaused = false;
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
    }
    
}
