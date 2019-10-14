using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    float x;
    float y;
    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(y * -1, 0, 0);
        transform.Rotate(0, x, 0, Space.World);
    }
}
