using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float shootingDistance = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float timeBetweenShots = 0.5f;

    [SerializeField] ParticleSystem shootingFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Camera FPSCamera;

    Ammo ammoSlot;
    bool canShoot = true;

    void Start() 
    {
        ammoSlot = GetComponent<Ammo>();    
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.AmmoAmount > 0)
        {
            ProcessMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    void ProcessMuzzleFlash()
    {
        shootingFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, shootingDistance))
        {
            ProcessHitEffect(hit);
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                enemy.GetComponent<EnemyAI>().IsProvoked = true;
            }
        }
        else
        {
            return;
        }
    }

    void ProcessHitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
