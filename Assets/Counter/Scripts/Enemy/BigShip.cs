using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShip : BaseEnemy
{
    [SerializeField] GameObject directionPoint;
    private Rigidbody enemyRb;
    [SerializeField] float speed = 3.0f;
    
    // Start is called before the first frame update
    protected void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        base.Start();
    }

    private void Update()
    {
        if (!isDestroyed) {
            base.Update();
        }
        
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
