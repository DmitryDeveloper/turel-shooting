using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSciprt : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gunPositionObject;
    [SerializeField] GameObject firePositionObject;
    [SerializeField] float power = 60.0f;
    [SerializeField] float turnSpeed = 50.0f;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalLeftMax = 240.0f;
    private float horizontalRightMax = 320.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get an object object from the pool
            GameObject pooledProjectile = ProjectilePooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = firePositionObject.transform.position; // position it at player
                pooledProjectile.GetComponent<Rigidbody>().velocity = gunPositionObject.transform.forward * power;
            }
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        gunPositionObject.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);
    }
}
