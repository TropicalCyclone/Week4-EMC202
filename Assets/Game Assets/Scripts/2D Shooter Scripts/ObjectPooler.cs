using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler current;
    public GameObject pooledObject;
    public int pooledAmount;
    public bool willGrow;
    int i;

    public List<GameObject> pooledObjects;

    private void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(i = 0; i < pooledObjects.Count; i++)
        {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
