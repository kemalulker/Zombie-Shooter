using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 6;

    Ammo ammo;

    void Start() 
    {
        ammo = FindObjectOfType<Ammo>(); 
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag != "Player") return;

        ammo.IncreaseCurrentAmmo(ammoAmount);
        Destroy(gameObject);
    } 
}
