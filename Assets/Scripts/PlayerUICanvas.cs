using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUICanvas : MonoBehaviour
{
    Ammo ammo;
    PlayerHealth playerHealth;

    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI healthText;

    void Awake() 
    {
        ammo = FindObjectOfType<Ammo>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        ammoText.text = "Ammo: " + ammo.AmmoAmount.ToString();
        healthText.text = "Health: " + playerHealth.Health.ToString();
    }

    void Update() 
    {
        HandleText();    
    }

    void HandleText()
    {
        ammoText.text = "Ammo: " + ammo.AmmoAmount.ToString();
        healthText.text = "Health: " + playerHealth.Health.ToString();
    }
}
