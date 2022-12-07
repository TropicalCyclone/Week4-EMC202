using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("Disable", 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponentInParent<EnemyBehaviour>();    
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Disable();
                break;
            case "Enemy":
                Disable();
                enemy.TakeHit(1);
                break;
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
