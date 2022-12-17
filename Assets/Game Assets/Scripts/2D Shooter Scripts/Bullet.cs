using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int Damage;
    GameObject effect;
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
                effect = ObjectPooler.current.GetPooledObject(PooledObject.ObjectType.effect);
                effect.transform.SetPositionAndRotation(transform.position, Random.rotation);
                effect.SetActive(true);
                Disable();
                break;
            case "Enemy":
                effect = ObjectPooler.current.GetPooledObject(PooledObject.ObjectType.effect);
                effect.transform.SetPositionAndRotation(transform.position, Random.rotation);
                effect.SetActive(true);
                Disable();
                if (enemy != null)
                    enemy.TakeHit(Damage);
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
