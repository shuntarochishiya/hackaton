using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static int GetDirection(Vector2 vector) {
        var normVector = vector.normalized;
        if (Math.Abs(normVector.y) > Math.Abs(normVector.x)) {
            if (normVector.y > 0) {
                return 0;
            } else {
                return 4;
            }
        } else {
            if (normVector.x > 0) {
                return 2;
            } else {
                return 6;
            }
        }
    }
}