using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSciprt : MonoBehaviour
{
    [SerializeField] GameObject player;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] float turnSpeed = 50.0f;

    //how to get child object?
    public Camera playerCamera;

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");

        playerCamera.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);

        //TODO Refactor
        Vector3 playerCameraPosY = playerCamera.transform.position + Vector3.down * 1.0f * Time.deltaTime * verticalInput;       
        playerCamera.transform.position = new Vector3(transform.position.x, playerCameraPosY.y, playerCamera.transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = player.transform.rotation;
    }
}
