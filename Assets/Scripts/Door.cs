using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator doorsAnimator;

    private void Awake() {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Open () {
        collider.enabled = false;
        doorsAnimator.SetBool("isOpen", true);
        spriteRenderer.sortingOrder = 2;
    }
}
