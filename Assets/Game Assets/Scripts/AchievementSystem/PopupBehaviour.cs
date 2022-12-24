using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DisablePopup", 5f);
    }

    private void DisablePopup()
    {
        gameObject.SetActive(false);
    }
}
