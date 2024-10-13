using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };

    public float correctRotation;
    [SerializeField] bool isPlaced = false;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if ((transform.eulerAngles.z >= correctRotation - 1) && (transform.eulerAngles.z <= correctRotation + 1))
        {
            isPlaced = true;
            gameManager.correctMove();
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if ((transform.eulerAngles.z >= correctRotation - 1) && (transform.eulerAngles.z <= correctRotation + 1) && isPlaced == false)
        {
            isPlaced = true;
            gameManager.correctMove();
        }
        else if (isPlaced == true)
        {
            isPlaced = false;
            gameManager.wrongMove();
        }
    }
}
