using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzle;

    private void Start()
    {
        puzzle.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Press F to open the puzzle");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                puzzle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            puzzle.SetActive(false);
        }
    }
}
