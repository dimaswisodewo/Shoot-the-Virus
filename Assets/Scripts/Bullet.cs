using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int minHeight = -30;
    private float destroyDelay = 5f;
    private bool isSendingToPool;

    private void Update()
    {
        if (gameObject.activeInHierarchy && !isSendingToPool)
        {
            StartCoroutine(SendToPool());
        }

        if (transform.position.y <= minHeight)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator SendToPool()
    {
        isSendingToPool = true;

        yield return new WaitForSeconds(destroyDelay);

        gameObject.SetActive(false);
        isSendingToPool = false;
    }

}
