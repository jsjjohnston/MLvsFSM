using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    [Tooltip("Object to be pooled")]
    public GameObject pooledGameObject = null; // Object to be pooled
    [Tooltip("Size of the object pool")]
    public int poolSize = 20; // Size of the object pool
    [Tooltip("Enable if you would like pool resize automatically")]
    public bool willGrow = true; // Enable if you would like pool resize automatically

    private List<GameObject> pooledGameObjects = null; // Object in the pool

    void Awake()
    {
        pooledGameObjects = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        //Instantiate Pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledGameObject, transform);
            obj.SetActive(false);
            obj.name = pooledGameObject.name + " (" + (i + 1) + ")";
            pooledGameObjects.Add(obj);
        }
    }

    // Get Next avilable object
    // Returns Null if no object is avilable
    public GameObject GetAvailableGameObj()
    {
        // Return a Already Pooled Object if Available
        for (int i = 0; i < pooledGameObjects.Count; i++)
        {
            if (!pooledGameObjects[i].activeInHierarchy)
            {
                return pooledGameObjects[i];
            }
        }

        // If set the object pool will increase automatically
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledGameObject);
            pooledGameObjects.Add(obj);
            obj.transform.parent = this.transform;
            poolSize++;
            obj.name = pooledGameObject.name + " (" + poolSize + ")";
            return obj;
        }

        //If no object is avilable in pool Null object is returned 
        return null;
    }

    // Returns a List of all Active objects in pool
    // Used for Save system
    public List<GameObject> GetActiveGameObjects()
    {
        List<GameObject> activeGameObjects = new List<GameObject>();

        foreach (GameObject item in pooledGameObjects)
        {
            if (item.activeInHierarchy)
            {
                activeGameObjects.Add(item);
            }
        }

        return activeGameObjects;
    }

    // Disables all object in pool
    // Used for Save system (make sure all are disabled on load)
    public void disableAll()
    {
        foreach (GameObject item in pooledGameObjects)
        {
            if (item.activeInHierarchy)
            {
                item.SetActive(false);
            }
        }
    }
}
