using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public SaveManager saveManager;
    public List<Achievement> achievement;
    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("Continue") == 0)
        {
            GetAchievements(1).isCompleted = false;
            GetAchievements(2).isCompleted = false;
        }
        else
        {
            GetAchievements(1).isCompleted = saveManager._localPlayerData.Achievements[0];
            GetAchievements(2).isCompleted = saveManager._localPlayerData.Achievements[1];
        }
        Actions.AchievementCheck += SetIngameAchievements;
    }
    private void OnDisable()
    {
        Actions.AchievementCheck -= SetIngameAchievements;
    }

    public void SetIngameAchievements(int Input, EndGameUI end)
    {

        if (Input >= 100 && GetAchievements(1).isCompleted == false)
        {
            GetAchievements(1).isCompleted = true;
            GetAchievements(1).Popup.SetActive(true);
        }
        else if (end.hasEnded)
        {
            if (Input == 0 && GetAchievements(2).isCompleted == false)
            {
                GetAchievements(2).isCompleted = true;
                GetAchievements(2).Popup.SetActive(true);
            }
        }
    }

    public Achievement GetAchievements(int Input)
    {
        for(int i = 0; i < achievement.Count; i++)
        {
           if(achievement[i].id == Input)
            {
                return achievement[i];
            }
        }
        return null;
    }
}


