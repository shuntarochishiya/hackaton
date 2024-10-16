using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField] int totalPipes = 0;

    int correctedPipes = 2;

    // Start is called before the first frame update
    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;

        Debug.Log("Correct move");

        if (correctedPipes == totalPipes)
        {
            Debug.Log("Everything's done");
            Invoke("destroy", 1f);
        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;
    }

    private void destroy()
    {
        Destroy(PipesHolder);
    }
}
