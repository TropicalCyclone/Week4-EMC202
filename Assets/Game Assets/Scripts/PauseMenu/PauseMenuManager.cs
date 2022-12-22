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
                PlayerPrefs.SetInt("isDisabled", 1);
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
        SceneManager.LoadScene("HomeScreen");
        FindObjectOfType<SaveManager>().Save(FindObjectOfType<PlayerController>().GetComponent<PlayerController>(),
            FindObjectOfType<EnemySpawnManager>().GetComponent<EnemySpawnManager>(),
            FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>());
        PlayerPrefs.SetInt("isDisabled", 0);
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        FindObjectOfType<ScoreManager>().ResetScore();
        PauseMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HidePauseScreen()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
    }
    
}
