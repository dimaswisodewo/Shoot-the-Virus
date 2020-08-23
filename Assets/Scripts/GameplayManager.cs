using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager sharedInstance;
    public Transform playerTransform;
    public int enemyAlive;

    private float minX = -10f;
    private float maxX = 10f;
    private float minZ = -10f;
    private float maxZ = 10f;
    private float minY = 1f;
    private float maxY = 5f;

    private void Awake()
    {
        sharedInstance = this;
        //enemyAlive = ObjectPooler.sharedInstance.amountEnemyToPool;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
        
        if (playerTransform.position.y < -100f)
        {
            RestartActiveScene();
        }

        if (enemyAlive <= 0)
        {
            Debug.Log("You Win!");
        }
    }

    private void SpawnEnemy()
    {
        GameObject obj = ObjectPooler.sharedInstance.GetPooledEnemy();

        if (obj != null)
        {
            Vector3 enemyPos = GetEnemyRandomPosition();

            obj.transform.position = enemyPos;
            obj.SetActive(true);
        }
    }

    private Vector3 GetEnemyRandomPosition()
    {
        float posX = Random.Range(minX, maxX);
        float posZ = Random.Range(minZ, maxZ);
        float posY = Random.Range(minY, maxY);

        Vector3 pos = new Vector3(posX, posY, posZ);
        return pos;
    }

    private void RestartActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
