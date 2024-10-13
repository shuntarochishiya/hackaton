using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter;
    private int onCount = 0;
    public bool solved;

    static public Counter Instance;

    private void Awake()
    {
        Instance = this;
        solved = false;
    }

    public void wiresConnect(int points)
    {
        onCount += points;
        if (onCount == counter)
        {
            solved = true;
            Invoke("destroy", 1.0f);
        }
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
