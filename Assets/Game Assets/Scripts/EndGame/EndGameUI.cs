using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public bool isPaused = false;
    
    public void ShowEndScreen()
    {
        Time.timeScale = 0f;
        PlayerPrefs.SetInt("isDisabled", 1);
        PauseMenu.gameObject.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Selection Screen");
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HideEndScreen()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
    }
    
}
