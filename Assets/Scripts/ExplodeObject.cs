using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObject : MonoBehaviour
{
    public Enemy enemyManager;
    public ParticleSystem explosionVFX;
    public TraumaInducer traumaInducer;
    public float minForce;
    public float maxForce;
    public float radius;

    private float destroyDelay = 5f;
    private bool isExploding;

    private void Update()
    {
        if (enemyManager.isTakeShot && !isExploding)
        {
            enemyManager.Dead();
            Explode();
        }        
    }

    public void Explode()
    {
        PlayExplosionVFX();
        isExploding = true;

        foreach (Transform t in transform)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius);
            }
            
        }

        Destroy(enemyManager.gameObject, destroyDelay);
    }

    private void PlayExplosionVFX()
    {
        if (!explosionVFX.isPlaying)
        {
            explosionVFX.Play();
            StartCoroutine(traumaInducer.StartShaking());
            //Debug.Log("Exploding!");
        }
        //else
        //{
        //    explosionVFX.Stop();
        //}
    }
    
}
