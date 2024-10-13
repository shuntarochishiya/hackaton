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
    [SerializeField] private Camera camera;
    [SerializeField] private AudioSource walkAudio;
    [SerializeField] private AudioSource gunShootAudio;
    [SerializeField] private AudioSource takeDamageAudio;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    public HealthSystem healthSystem;
    bool canShoot = true;
    private AnimationController animationController;

    private void Awake()
    {
        healthSystem = gameObject.AddComponent<HealthSystem>();
        healthSystem.SetHealth(30);
        _rigidbody = GetComponent<Rigidbody2D>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        Debug.Log("Health: " + healthSystem.GetHealth());
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _speed;
        if (Math.Abs(_movementInput.x) > float.Epsilon || Math.Abs(_movementInput.y) > float.Epsilon)
        {
            if (!walkAudio.isPlaying)
            {
                walkAudio.Play();
            }
        } 
        else 
        {
            walkAudio.Stop();
        }
        animationController.AnimateObject("Direction", AnimationController.GetDirection(_movementInput));
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            bullets.CreateBullet(mousePos - _rigidbody.position);
            gunShootAudio.Play();
            SetFalseAfter(100, 1000);
        }

        if (healthSystem.GetHealth() == 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int value) {
        healthSystem.TakeDamage(value);
        takeDamageAudio.Play();
    }

    public Vector2 GetCurrentPosition()
    {
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
