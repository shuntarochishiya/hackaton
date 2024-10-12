using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthSystem healthBar;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Health: " + currentHealth);

        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentHealth != 0)
        {
            TakeDamage(10);
            Debug.Log("Health: " + currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.E) && currentHealth != 100)
        {
            Heal(10);
            Debug.Log("Health: " + currentHealth);
        }

        if (currentHealth == 0)
        {
            Debug.Log("Dead");
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void Heal(int healing)
    {
        currentHealth += healing;

        healthBar.SetHealth(currentHealth);
    }
}
