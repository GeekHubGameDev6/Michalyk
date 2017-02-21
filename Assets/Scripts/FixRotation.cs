using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public GameObject canvas;
    Quaternion rotation;
    void Awake()
    {
        rotation = canvas.transform.rotation;
    }
    void LateUpdate()
    {
        canvas.transform.rotation = rotation;
    }
}
