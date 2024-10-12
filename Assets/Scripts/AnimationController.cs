using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimateObject(string animationName, int direction)
    {
        animator.SetInteger(animationName, direction);
    }

    public static int getDirection(Vector2 vector) {
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