using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject _camera;

    void Start()
    {
        _camera = GameObject.Find("MainCamera");
    }

    void Update()
    {
        transform.LookAt(_camera.transform);
    }
}
