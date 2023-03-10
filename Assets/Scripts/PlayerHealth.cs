using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    private int _maxHealth = 15;
    
    public float floatingDuration;
    private float floatingTime;

    public List<GameObject> objectsToDisable;

    public bool isPowerUp = false;

    private void OnEnable()
    {
        BaloonCollect.baloonCollected += AddHealth;
    }

    private void OnDisable()
    {
        BaloonCollect.baloonCollected -= AddHealth;
    }

    private void Awake()
    {
        currentHealth = _maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacles"))
        {
            objectsToDisable[currentHealth-1].SetActive(false);
            currentHealth--;
            
        }
    }

    public bool IsFullHealth()
    {
        return currentHealth == _maxHealth;
    }

    public void AddHealth()
    {
        if (currentHealth < _maxHealth)
        {
            currentHealth++;
            objectsToDisable[currentHealth-1].SetActive(true);
            
        }
        else
        {
            PowerUp();
        }
    }

    public void PowerUp()
    {
        isPowerUp = true;
        Debug.Log("PowerUp");
    }
}
