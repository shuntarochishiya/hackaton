using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider.SetActive(true);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorCollider.SetActive(false);
            Destroy(gameObject);
        }
    }
}
