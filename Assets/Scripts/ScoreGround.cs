using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGround : MonoBehaviour
{
    public float height;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
    private void OnEnable()
    {
        
    }
}
