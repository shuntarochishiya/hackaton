using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor {
    GreenKey,
    RedKey,
    BlueKey,
}

public class Key : MonoBehaviour
{
    [SerializeField] private KeyColor color;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inventory = Inventory.getInstance();

        if (collision.CompareTag("Player"))
        {
            inventory.keys.Add(color);

            Destroy(gameObject);
        }
    }
}
