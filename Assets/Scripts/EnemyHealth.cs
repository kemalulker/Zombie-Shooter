using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    
    bool isDead = false;

    public bool IsDead { get => isDead; }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        if(!isDead)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("dead");
        }   
    }
}
