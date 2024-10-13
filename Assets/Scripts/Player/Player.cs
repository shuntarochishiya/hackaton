using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private HealthSystem _healthSystem;
    private AnimationController animationController;


    private void Awake()
    {
        _healthSystem = gameObject.AddComponent<HealthSystem>();
        _healthSystem.SetHealth(100);
        _rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        Debug.Log("Health: " + _healthSystem.GetHealth());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _speed;
        animationController.AnimateObject("Direction", AnimationController.getDirection(_movementInput));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _healthSystem.GetHealth() != 0)
        {
            _healthSystem.TakeDamage(10);
            Debug.Log("Health: " + _healthSystem.GetHealth());
        }

        if (Input.GetKeyDown(KeyCode.E) && _healthSystem.GetHealth() != 100)
        {
            _healthSystem.GetHeal(10);
            Debug.Log("Health: " + _healthSystem.GetHealth());
        }

        if (_healthSystem.GetHealth() == 0)
        {
            Debug.Log("Dead");
        }
    }

    public Vector2 GetCurrentPosition() {
        return _rigidbody.position;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
