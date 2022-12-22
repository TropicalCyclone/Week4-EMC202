using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    [SerializeField] private TMP_Text scoreNumber;
    public void AddToScore(int amount)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + amount);
        scoreNumber.SetText("" + PlayerPrefs.GetInt("Score"));
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
