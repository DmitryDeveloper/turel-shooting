using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBorderPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 30) {
            Destroy(gameObject);
        }
    }
}
