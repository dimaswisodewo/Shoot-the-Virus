using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : StateMachineBehaviour
{
    public Transform[] patrolSpot;
    public Transform playerTranform;
    public float speed = 10f;
    
    private Transform startPosition;
    private int movePosition;
    private float startWaitTime = 2f;
    private float waitTime;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        movePosition = Random.Range(0, patrolSpot.Length);
        waitTime = startWaitTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, playerTranform.position) < 6)
        {
            animator.SetBool("isPatrolling", false);
            return;
        }

        animator.transform.position = Vector3.MoveTowards(animator.transform.position, patrolSpot[movePosition].position, speed * Time.deltaTime);

        if (Vector3.Distance(animator.transform.position, patrolSpot[movePosition].position) < 0.2f)
        {
            if (waitTime >= 0f)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                movePosition = Random.Range(0, patrolSpot.Length);
                waitTime = startWaitTime;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
