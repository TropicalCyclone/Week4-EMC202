using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectionScreenManager : MonoBehaviour
{
    public PlayerController playerController;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private PlayerClassDatabase playerClassDatabase;
    GameObject obj;
    [SerializeField] private TMP_Text textMesh;
    // Start is called before the first frame update
    private void OnEnable()
    {
       playerController = GetComponent<PlayerController>();
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void SingleTankButtonHover()
    {
        obj = Instantiate(GetPlayer("0001").PlayerModel, spawnpoint.position, Quaternion.Euler(0, 0, 0));
        obj.gameObject.tag = "Untagged";
        obj.SetActive(true);
        obj.transform.localScale = new Vector3(1,1,1);
        PlayerPrefs.SetInt("isDisabled", 1);
        textMesh.text = GetPlayer("0001").itemDesc;
    }
    public void DualTankButtonHover()
    {
        obj = Instantiate(GetPlayer("0002").PlayerModel, spawnpoint.position, Quaternion.Euler(0, 0, 0));
        obj.gameObject.tag = "Untagged";
        obj.SetActive(true);
        obj.transform.localScale = new Vector3(1, 1, 1);
        PlayerPrefs.SetInt("isDisabled", 1);
        textMesh.text = GetPlayer("0002").itemDesc;
    }

    public void QuadTankButtonHover()
    {
        obj = Instantiate(GetPlayer("0003").PlayerModel, spawnpoint.position, Quaternion.Euler(0, 0, 0));
        obj.gameObject.tag = "Untagged";
        obj.SetActive(true);
        obj.transform.localScale = new Vector3(1, 1, 1);
        PlayerPrefs.SetInt("isDisabled", 1);
        textMesh.text = GetPlayer("0003").itemDesc;
    }

    public void TankDelete()
    {
        Destroy(obj);
        textMesh.text = "";
    }


    public void SingleTankButton()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        PlayerPrefs.SetString("player_class", "0001");
        SceneManager.LoadScene("Game");
    } 
    public void TwinTankButton()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        PlayerPrefs.SetString("player_class", "0002");
        SceneManager.LoadScene("Game");
    }

    public void QuadTankButton()
    {
        PlayerPrefs.SetInt("isDisabled", 0);
        PlayerPrefs.SetString("player_class", "0003");
        SceneManager.LoadScene("Game");
    }



    public PlayerClass GetPlayer(string ID)
    {
        for (int i = 0; i < playerClassDatabase.allClasses.Count; i++)
        {
            PlayerClass item = playerClassDatabase.allClasses[i];
            if (item.classID == ID)
                return item;
        }
        PlayerPrefs.SetFloat("player_HP", 10);
        return GetPlayer("0001");
    }

    
}
