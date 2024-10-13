using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float PARALLAX_FACTOR = 0.5f;
    [SerializeField] private Camera _camera;
    private Vector3 _previousSelfPosition;
    private Vector3 _previousCameraPosition;

    void Start() {
        _previousSelfPosition = transform.position;
        _previousCameraPosition = _camera.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = (_camera.transform.position - _previousCameraPosition) * PARALLAX_FACTOR + _previousSelfPosition;
        
        _previousSelfPosition = transform.position;
        _previousCameraPosition = _camera.transform.position;
    }
}
