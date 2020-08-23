using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform cameraTransform;
    public Animator gunAnimator;
    public ParticleSystem muzzleFlash;
    //private float damage = 20f;
    //private float shootForce = 500f;
    private float raycastRange = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            PlayShotAnimation(true);
            muzzleFlash.Play();
        }
        else
        {
            PlayShotAnimation(false);
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, raycastRange))
        {
            //GameObject bullet = ObjectPooler.sharedInstance.GetPooledBullet();

            //if (bullet != null)
            //{
            //    bullet.transform.position = transform.position;
            //    bullet.transform.rotation = transform.rotation;
            //    bullet.SetActive(true);
            //    bullet.transform.LookAt(hit.transform.position);

            //    Vector3 aimSpot = hit.transform.position;
            //    Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //    rb.AddForce(aimSpot * shootForce);
            //}

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.isTakeShot = true;
            }
        }
    }

    private void PlayMuzzleFlashVFX()
    {
        if (!muzzleFlash.isPlaying)
        {
            muzzleFlash.Play();
        }
    }

    private void PlayShotAnimation(bool setActive)
    {
        gunAnimator.SetBool("isShooting", setActive);
    }

}
