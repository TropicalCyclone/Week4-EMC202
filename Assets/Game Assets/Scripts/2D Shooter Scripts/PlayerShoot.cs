using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PauseMenuManager pause;
    public static Action shootInput;
    private void Start()
    {
        pause = GameObject.FindWithTag("UIDisplay").GetComponent<PauseMenuManager>();
    }
    void Update()
    {
        if (!pause.isPaused)
        {
            if (Input.GetMouseButton(0))
            {
                shootInput?.Invoke();
            }
        }
    }
}
