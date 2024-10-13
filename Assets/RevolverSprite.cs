using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverSprite : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject revolver;

    void Update()
    {
        Inventory inventory = Inventory.getInstance();
        if (!inventory.hasRevolver) {
            revolver.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            revolver.GetComponent<SpriteRenderer>().enabled = true;
        }

        Vector3 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = mousePos - gameObject.GetComponentInParent<Transform>().position;
        float rotation_z = -1 * Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, -rotation_z);

        if (diff.x < 0) {
            revolver.transform.rotation = Quaternion.Euler(180f, 180f, 180f);
        } else {
            revolver.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
