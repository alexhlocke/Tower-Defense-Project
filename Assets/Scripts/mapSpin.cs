using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapSpin : MonoBehaviour
{
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0f, 0.07f*direction, 0f, Space.World);
        
        if (transform.rotation.y > 0.18f || transform.rotation.y < -0.05f) {
            direction *= -1;
        }
        //Debug.Log(direction + " | " + transform.rotation.y);
    }
}
