using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !door.activeInHierarchy)
        {
            Debug.Log("Entering a new location...");
        }
    }
}
