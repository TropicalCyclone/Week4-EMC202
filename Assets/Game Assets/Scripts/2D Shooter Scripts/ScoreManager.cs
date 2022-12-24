using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    private void OnEnable()
    {
        scoreNumber.SetText("0");
        Actions.OnEnemyKilled += AddToScore;
    }

    private void OnDisable()
    {
        Actions.OnEnemyKilled -= AddToScore;
    }

    [SerializeField] private TMP_Text scoreNumber;
    public void AddToScore(EnemyBehaviour enemy)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + enemy.ScoreWhenKilled);
        scoreNumber.SetText("" + PlayerPrefs.GetInt("Score"));
        Actions.AchievementCheck(PlayerPrefs.GetInt("Score"), FindObjectOfType<EndGameUI>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResetScore();
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        scoreNumber.SetText("" + PlayerPrefs.GetInt("Score"));
    }
}
