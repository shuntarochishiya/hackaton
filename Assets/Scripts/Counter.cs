using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int counter;
    private int onCount = 0;

    static public Counter Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void wiresConnect(int points)
    {
        onCount += points;
        if (onCount == counter)
        {
            Invoke("destroy", 1.0f);
            Debug.Log("Everything's done");
        }
    }

    private void destroy()
    {
        Destroy(this.gameObject);
    }
}
