using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    [SerializeField] private KeyColor color;
    [SerializeField] private Door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = Inventory.getInstance();

        if (collision.CompareTag("Player"))
        {
            if (inventory.keys.Contains(color)) {
                door.Open();
                inventory.keys.Remove(color);
                Destroy(gameObject);
            }
        }
    }
}
