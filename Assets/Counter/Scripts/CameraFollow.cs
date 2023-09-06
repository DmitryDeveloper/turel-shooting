using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSciprt : MonoBehaviour
{
    public GameObject player;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] float turnSpeed = 10.0f;

    // private Vector3 offset = new Vector3(0, 20, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        Vector3 rotation = new Vector3(0f, 1.0f * horizontalInput * turnSpeed, 0f);
        transform.Rotate(rotation * Time.deltaTime);

        


        transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);
    }
}