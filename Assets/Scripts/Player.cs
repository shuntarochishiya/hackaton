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

    public GameObject Puzzle;

    public Animator anim;


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

        if (_rigidbody.velocity.y > 0.01f && _rigidbody.velocity.x > 0.01f)
        {
            anim.SetBool("NE", true);
        }
        else
        {
            anim.SetBool("NE", false);
        }
        if (_rigidbody.velocity.y < -0.01f && _rigidbody.velocity.x > 0.01f)
        {
            anim.SetBool("SE", true);
        }
        else
        {
            anim.SetBool("SE", false);
        }
        if (_rigidbody.velocity.y < -0.01f && _rigidbody.velocity.x < -0.01f)
        {
            anim.SetBool("SW", true);
        }
        else
        {
            anim.SetBool("SW", false);
        }
        if (_rigidbody.velocity.y > 0.01f && _rigidbody.velocity.x < -0.01f)
        {
            anim.SetBool("NW", true);
        }
        else
        {
            anim.SetBool("NW", false);
        }

        if (_rigidbody.velocity.y > 0.01f && _rigidbody.velocity.x == 0f)
        {
            anim.SetBool("N", true);
        }
        else
        {
            anim.SetBool("N", false);
        }
        if (_rigidbody.velocity.y < -0.01f && _rigidbody.velocity.x == 0f)
        {
            anim.SetBool("S", true);
        }
        else
        {
            anim.SetBool("S", false);
        }
        if (_rigidbody.velocity.x > 0.01f && _rigidbody.velocity.y == 0f)
        {
            anim.SetBool("E", true);
        }
        else
        {
            anim.SetBool("E", false);
        }
        if (_rigidbody.velocity.x < -0.01f && _rigidbody.velocity.y == 0f)
        {
            anim.SetBool("W", true);
        }
        else
        {
            anim.SetBool("W", false);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Puzzle")
        {
            Debug.Log("Press F to enter the puzzle");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Puzzle")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Puzzle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Puzzle")
        {
            Puzzle.SetActive(false);
        }
    }


}
