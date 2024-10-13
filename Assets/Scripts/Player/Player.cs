using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] public Bullets bullets;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    public HealthSystem healthSystem;
    bool canShoot = true;
    [SerializeField] private AnimationController animationController;

    private void Awake()
    {
        healthSystem = gameObject.AddComponent<HealthSystem>();
        healthSystem.SetHealth(30);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log("Health: " + healthSystem.GetHealth());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _speed;
        animationController.AnimateObject("Direction", AnimationController.getDirection(_movementInput));
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot) {
            canShoot = false;
            Vector3 mousePos = Input.mousePosition;
            SpamBullet((Vector2) mousePos - new Vector2(960, 540));
            SetFalseAfter(100, 1000);
        }

        if (healthSystem.GetHealth() == 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    private void SpamBullet(Vector2 direction) {
        bullets.CreateBullet(direction);
    }

    public Vector2 GetCurrentPosition() {
        return _rigidbody.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touched alian");
    }

    private async Task SetFalseAfter(int animationTime, int waitTime)
    {
        await Task.Delay(animationTime);
        Debug.Log("Player shooted");
        await Task.Delay(waitTime);
        canShoot = true;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
