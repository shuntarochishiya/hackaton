using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private const float _speed = 30f;
    [SerializeField] public Sprite sprite;
    long bulletCounter = 0;

    public void CreateBullet(Vector2 direction)
    {
        GameObject newGameObject = new GameObject("Bullet" + bulletCounter++);
        Bullet bullet = newGameObject.AddComponent<Bullet>();
        bullet.Initialize(direction.normalized, gameObject.transform.position, sprite);
    }

    class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private SpriteRenderer sprite;
        private Vector2 direction;
        private BoxCollider2D boxCollider2D;
        private DateTime creationTime;

        public void Initialize(Vector2 direction, Vector2 position, Sprite sprite)
        {
            this.direction = direction;

            this.sprite = gameObject.AddComponent<SpriteRenderer>();
            this.sprite.sprite = sprite;

            _rigidbody = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody.position = position + direction;
            _rigidbody.gravityScale = 0;
            _rigidbody.freezeRotation = true;

            boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
            boxCollider2D.size = new Vector2(0.1f, 0.1f);

            gameObject.tag = "Bullet";

            creationTime = DateTime.Now;
        }

        public void FixedUpdate()
        {
            _rigidbody.velocity = direction * _speed;
            if (TimeSpan.Compare(DateTime.Now - creationTime, new TimeSpan(TimeSpan.TicksPerSecond)) >= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}