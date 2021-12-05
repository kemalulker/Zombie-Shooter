using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int AmmoAmount { get => ammoAmount; }

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }

    public void IncreaseCurrentAmmo(int amountToIncrease)
    {
        ammoAmount += amountToIncrease;
    }
}
