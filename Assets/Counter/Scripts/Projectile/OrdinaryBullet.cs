using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile
{
    public float speed = 40.0f;

    private Rigidbody projectibleRb;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        projectibleRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            gameManager.UpdateCount(1);
        }

        gameObject.SetActive(false);
    }
}
