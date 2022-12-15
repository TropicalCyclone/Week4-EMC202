using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SingleTankButton()
    {
        PlayerPrefs.SetString("player_class", "0001");
        SceneManager.LoadScene("Game");
    } 
    public void TwinTankButton()
    {
        PlayerPrefs.SetString("player_class","0002");
        SceneManager.LoadScene("Game");
    }

}
