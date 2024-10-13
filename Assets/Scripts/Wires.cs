using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Wires : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 startPosition;
    public SpriteRenderer wireEnd;
    public GameObject lightOn;

    [SerializeField] private AudioClip connected;
    private AudioSource audioSource;

    private void Start()
    {
        startPosition = transform.position;
        startPoint = transform.parent.position + new Vector3(0, .22f, 0);   
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                updateWire(collider.transform.position);

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    collider.GetComponent<Wires>()?.done();
                    done();
                }
                return;
            }
        }

        updateWire(newPosition);
    }

    void done()
    {
        lightOn.SetActive(true);
        Debug.Log("Connected successfully");

        audioSource.clip = connected;
        audioSource.Play();

        Counter.Instance.wiresConnect(1);

        Destroy(this);
    }

    private void OnMouseUp()
    {
        updateWire(startPosition);
    }

    void updateWire(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);
    }
}
