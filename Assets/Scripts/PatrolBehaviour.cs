using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    public List<Transform> patrolSpot;
    public Transform playerTranform;
    public Animator enemyAnim;
    public float speed = 10f;
    public float minDistance = 15f;

    private Transform startPosition;
    private int movePosition;
    private float startWaitTime = 0.5f;
    private float waitTime;
    
    private void Awake()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
        movePosition = Random.Range(0, patrolSpot.Count);
        waitTime = startWaitTime;
    }
    
    private void Update()
    {
        if (enemyAnim.GetBool("isPatrolling"))
        {
            if (Vector3.Distance(transform.position, playerTranform.position) < minDistance)
            {
                enemyAnim.SetBool("isPatrolling", false);
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, patrolSpot[movePosition].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolSpot[movePosition].position) < 0.2f)
            {
                if (waitTime >= 0f)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    movePosition = Random.Range(0, patrolSpot.Count);
                    waitTime = startWaitTime;
                }
            }
        }        
    }

}
