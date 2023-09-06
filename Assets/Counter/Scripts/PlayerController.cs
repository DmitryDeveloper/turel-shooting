using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSciprt : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject gunPositionObject;
    public GameObject firePositionObject;
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
            GameObject projectile = Instantiate(projectilePrefab, firePositionObject.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = gunPositionObject.transform.forward * power;
            // projectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * power);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        gunPositionObject.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);
    }
}
