using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShip : BaseEnemy
{
    [SerializeField] GameObject directionPoint;
    private Rigidbody enemyRb;
    [SerializeField] float speed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(Vector3.down);
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
