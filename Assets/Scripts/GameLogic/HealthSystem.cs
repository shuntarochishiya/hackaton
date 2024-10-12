using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    // [SerializeField] private Slider _healthSlider;
    // [SerializeField] private Gradient _gradient;
    // [SerializeField] private Image _fill;

    public void SetHealth(int health)
    {
        _currentHealth = Math.Max(0, health);
        // _healthSlider.value = _currentHealth;
        // _fill.color = _gradient.Evaluate(_healthSlider.normalizedValue);
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
