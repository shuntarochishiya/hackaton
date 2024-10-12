using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AlianCockroach : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player player;
    [SerializeField] private AnimationController animationController;
    private Rigidbody2D _rigidbody;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = gameObject.AddComponent<HealthSystem>();
        _healthSystem.SetHealth(100);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log("Health: " + _healthSystem.GetHealth());
    }

    private void FixedUpdate()
    {
        var direction = (player.GetCurrentPosition() - _rigidbody.position).normalized;
        _rigidbody.velocity = direction * _speed;
        animationController.AnimateObject("Direction", AnimationController.getDirection(direction));
    }

    private void Update()
    {
        
    }
}
