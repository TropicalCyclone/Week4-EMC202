using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text HighscoreText;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private GameObject PauseMenu;
    public bool isPaused = false;

    public void SetHighscoreText(string input)
    {
        HighscoreText.SetText("" + input);
    }

    public void SetScoreText(string input)
    {
        ScoreText.SetText("" + input);
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        HighscoreText.SetText("" + PlayerPrefs.GetInt("Highscore"));
    }
    public void ShowEndScreen()
    {
        Time.timeScale = 0f;
        PlayerPrefs.SetInt("isDisabled", 1);
        PauseMenu.gameObject.SetActive(true);

        SetScoreText(PlayerPrefs.GetInt("Score").ToString());

        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
            SetHighscoreText(PlayerPrefs.GetInt("Highscore").ToString() + " NEW HIGHSCORE!!");
        }
        else
        {
            SetHighscoreText(PlayerPrefs.GetInt("Highscore").ToString());
        }
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void ReturnToSelect()
    {
        SceneManager.LoadScene("Selection Screen");
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Score", 0);
        PauseMenu.gameObject.SetActive(false);
        FindObjectOfType<ScoreManager>().ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HideEndScreen()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        Time.timeScale = 1f;
        PauseMenu.gameObject.SetActive(false);
    }
    
}
