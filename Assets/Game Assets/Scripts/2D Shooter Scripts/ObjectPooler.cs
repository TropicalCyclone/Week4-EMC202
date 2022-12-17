using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPooler : MonoBehaviour
{
    private static ObjectPooler _current; 
    public static ObjectPooler current { get { return _current; } }
    int i;

    public List<PooledObject> objectDatabase;

    public List<GameObject> pooledObjects;

    private void Awake()
    {

        if (current == null )
        {
            _current = this;
            DontDestroyOnLoad(this);
            
        }
        else if (current != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        pooledObjects = new List<GameObject>();
        
        
    }

    public GameObject GetPooledObject(PooledObject.ObjectType objectType)
    {
        GameObject target = null; 
        
        for (i = 0; i < objectDatabase.Count; i++)
        {
            if (objectDatabase[i].objectType == objectType)
            {
                target = objectDatabase[i].go;

                foreach (GameObject pooledObject in pooledObjects)
                {
                    if (!pooledObject.activeInHierarchy && pooledObject.tag == objectDatabase[i].go.tag)
                    {
                        return pooledObject;

                    }
                }
                
                if (objectDatabase[i].willGrow)
                {
                    GameObject obj = Instantiate(target, this.transform);
                    pooledObjects.Add(obj);
                    obj.SetActive(false);
                    return obj;
                }
            }
        }
        return null;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        pooledObjects.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


}
[System.Serializable]
public class PooledObject
{
    public GameObject go;
    public int pooledAmount;
    public bool willGrow;
    public ObjectType objectType;
    public enum ObjectType
    {
       enemy = 0,bullet = 1,effect = 2
    }
}
