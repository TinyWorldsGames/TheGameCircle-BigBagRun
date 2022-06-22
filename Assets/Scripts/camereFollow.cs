using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camereFollow : MonoBehaviour
{
    public Transform bag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (bag.transform.position.x - 4.83f, bag.transform.position.y + 3.5f, transform.position.z);


    }
}
