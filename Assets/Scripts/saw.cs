using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    public bool canMove;
    public float speed = 2;
    void Update()
    {
        transform.Rotate(0, 0, -speed);
        if (canMove)
        {
            GetComponent<Animator>().enabled = true;
            speed = 4;

        }
        
    }
}
