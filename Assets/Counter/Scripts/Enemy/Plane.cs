using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : BaseEnemy
{
    public GameObject directionPoint;
    private Rigidbody enemyRb;
    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
