using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Start()
    { 
    }


    void Update()
    {
        transform.Rotate(0f,50f * Time.deltaTime, 0f, Space.Self);
    }
}
