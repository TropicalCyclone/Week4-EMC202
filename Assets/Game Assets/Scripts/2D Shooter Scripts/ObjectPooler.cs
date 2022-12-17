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
        for (i = 0; i < objectDatabase.Count; i++)
        {
        }
    }

    public GameObject GetPooledObject(PooledObject.ObjectType objectType)
    {
        GameObject target = null; 
        
        for (i = 0; i < objectDatabase.Count; i++)
        {
            if (objectDatabase[i].objectType == objectType)
            {
                target = objectDatabase[i].go;
                foreach (var pooledObject in pooledObjects)
                {
                    if (!pooledObject.activeInHierarchy && pooledObject == objectDatabase[i].go)
                    {
                        Debug.Log("found object");
                        return pooledObject;
                    }
                }
                
                Debug.Log("Cant find object");
                if (objectDatabase[i].willGrow)
                {
                    GameObject obj = Instantiate(target, this.transform);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        pooledObjects.Clear();
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
       enemy = 0,bullet = 1
    }
}
