using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class AlianCockroach : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player player;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private AnimationController attack;
    [SerializeField] private AudioSource walkAudio;
    private Rigidbody2D _rigidbody;
    public HealthSystem healthSystem;
    private bool canAttack = true;

    private void Awake()
    {
        healthSystem = gameObject.AddComponent<HealthSystem>();
        healthSystem.SetHealth(20);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Debug.Log("Health: " + healthSystem.GetHealth());
    }

    private void FixedUpdate()
    {
        Vector2 dist = player.GetCurrentPosition() - _rigidbody.position;
        var inventory = Inventory.getInstance();

        var direction = (dist).normalized;
        
        if (Math.Sqrt(dist.x * dist.x + dist.y * dist.y) >= 2 && !inventory.hasRevolver) {
            return;
        }

        _rigidbody.velocity = direction * _speed;

        if (_rigidbody.velocity.magnitude > float.Epsilon)
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
        animationController.animator.SetInteger("Direction", AnimationController.GetDirection(direction));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack && collision.gameObject.tag == "Player")
        {
            attack.animator.SetBool("isAttack", true);
            canAttack = false;
            SetFalseAfter(100, 1000);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            healthSystem.TakeDamage(10);
        }
    }

    private void Update()
    {
        if (healthSystem.GetHealth() == 0)
        {
            Destroy(gameObject);
        }
    }

    private async Task SetFalseAfter(int animationTime, int waitTime)
    {
        await Task.Delay(animationTime);
        attack.animator.SetBool("isAttack", false);
        player.TakeDamage(10);
        Debug.Log("Player health: " + player.healthSystem.GetHealth());
        await Task.Delay(waitTime);
        canAttack = true;
    }
}
