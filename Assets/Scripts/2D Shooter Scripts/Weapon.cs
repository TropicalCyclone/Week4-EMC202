using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 20f;

    public void Fire()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null)
        {
            return;
        }
        else
        {
            obj.SetActive(true);
            obj.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
            obj.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
    }
}
