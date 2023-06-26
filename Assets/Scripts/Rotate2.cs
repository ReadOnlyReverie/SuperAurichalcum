using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public Transform center;
    public float degreesPerSecond = -70.0f;
    private Vector3 v;

    void Start()
    {
        v = transform.position - center.position;
    }

    void Update()
    {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.down) * v;
        transform.position = center.position + v;
    }

}
