using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth;

    public void SetHealth(int health)
    {
        _currentHealth = Math.Max(0, health);
    }

    public void TakeDamage(int damage)
    {
        SetHealth(_currentHealth - damage);
    }

    public void GetHeal(int healing)
    {
        SetHealth(_currentHealth + healing);
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}
