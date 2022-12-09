using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 20f;
    [SerializeField] GunData gunData;
    float timeSinceLastShot;

    public void Start()
    {
        PlayerShoot.shootInput += Fire;
    }
    private bool CanShoot() => timeSinceLastShot > 1f /(gunData.fireRate / 60f); 

    public void Fire()
    {
        switch (gunData.name)
        {
            case "Rifle":
                if (CanShoot())
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

                    timeSinceLastShot = 0;
                }
                break;
            case "Shotgun":
                if (CanShoot())
                {
                    GameObject obj = ObjectPooler.current.GetPooledObject();
                    if (obj == null)
                    {
                        return;
                    }
                    else
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            obj = ObjectPooler.current.GetPooledObject();
                            obj.SetActive(true);
                            obj.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
                            
                            switch (i)
                            {
                                case 0:
                                    obj.transform.Rotate(0f, 0f, -30f);
                                    obj.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                                    
                                    break;
                                case 1:
                                    obj.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);

                                    break;
                                case 2:
                                    obj.transform.Rotate(0f, 0f, 30f);
                                    obj.GetComponent<Rigidbody2D>().AddForce(transform.up * fireForce, ForceMode2D.Impulse);
                                    break;
                            }
                            
                        }
                        
                        
                    }

                    timeSinceLastShot = 0;
                }
                break;
        }

        
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
    }
}
