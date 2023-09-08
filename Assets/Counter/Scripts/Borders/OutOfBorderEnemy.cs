using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBorderEnemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 40) {
            Destroy(gameObject);
        }
    }
}
