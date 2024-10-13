using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // 0 - up
    // 2 - right
    // 4 - down
    // 6 - left
    public void AnimateObject(string animationName, int direction)
    {
        animator.SetInteger(animationName, direction);
    }

    public static int getDirection(Vector2 vector) {
        var normVector = vector.normalized;

        if (Math.Abs(normVector.y) == 0 && Math.Abs(normVector.x) == 0)
        {
            return 8;
        }

        if (Math.Abs(normVector.y) > Math.Abs(normVector.x)) {
            if (normVector.y > 0) {
                return 0;
            } else {
                return 4;
            }
        } else if (Math.Abs(normVector.y) < Math.Abs(normVector.x))
        {
            if (normVector.x > 0) {
                return 2;
            } else {
                return 6;
            }
        }
        else
        {
            if (normVector.y == normVector.x)
            {
                if (normVector.y > 0)
                {
                    return 1;
                }
                else
                {
                    return 5;
                }
            }
            else if (normVector.y < normVector.x) {
                return 3;
            }
            else 
            {
                return 7;
            }
        }
    }
}