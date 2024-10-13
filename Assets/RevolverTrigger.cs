using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RevolverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject revolver;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            Inventory inventory = Inventory.getInstance();

            inventory.hasRevolver = true;

            Destroy(revolver);
            Destroy(gameObject);
        }
    }
}
