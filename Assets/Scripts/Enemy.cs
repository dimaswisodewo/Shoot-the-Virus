using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public bool isTakeShot;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        SphereCollider collider =  transform.GetComponent<SphereCollider>();
    //        collider.enabled = false;
    //        animator.enabled = false;
    //        isDead = true;
    //        GameplayManager.sharedInstance.enemyAlive--;
    //    }
    //}

    public void Dead()
    {
        SphereCollider collider = transform.GetComponent<SphereCollider>();
        collider.enabled = false;
        animator.SetBool("isPatrolling", false);
        animator.SetBool("isFollowing", false);
        animator.enabled = false;
        GameplayManager.sharedInstance.enemyAlive -= 1;
    }
}
