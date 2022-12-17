using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DisableFX", 0.3f);
    }
    private void DisableFX()
    {
       gameObject.SetActive(false);
    }
}
