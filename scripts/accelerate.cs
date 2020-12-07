using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 1;
    }

    void Update()
    {
        transform.Translate(Input.acceleration.x * speed, 0, Input.acceleration.z * speed);
    }
}
