using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    int health = 100;

    public int Health { get => health; }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        health -= ((int)damage);
        if(hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
