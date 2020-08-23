using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    public List<GameObject> bulletPool = new List<GameObject>();
    public GameObject bulletToPool;
    public List<GameObject> enemyPool = new List<GameObject>();
    public GameObject enemyToPool;
    public int amountBulletToPool;
    public int amountEnemyToPool;
    private int amountOfEnemySpawned = 0;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        ObjectPooling(bulletToPool, bulletPool, amountBulletToPool);
        ObjectPooling(enemyToPool, enemyPool, amountEnemyToPool);
    }

    public GameObject GetPooledBullet()
    {
        GameObject obj = GetPooledObject(bulletPool);
        return obj;
    }

    public GameObject GetPooledEnemy()
    {
        if (amountOfEnemySpawned == amountEnemyToPool)
        {
            Debug.Log("Enemy Pool Empty");
            return null;
        }

        GameObject obj = enemyPool[amountOfEnemySpawned];
        amountOfEnemySpawned++;
        return obj;
    }

    private GameObject GetPooledObject(List<GameObject> objectPool)
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        return null;
    }

    private void ObjectPooling(GameObject objectToPool, List<GameObject> objectPool, int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

}
