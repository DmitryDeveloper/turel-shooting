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

    private GameManager GameManager;

    void Start()
    {
        //TODO should be singleton?
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameActive) {
            return;
        }

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

        if (CanRotateGun(verticalInput)) {
            gunPositionObject.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);            
        }
        
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);
    }

    // Should rotate between [6 - 0, 360 - 300]
    // TODO can be replaces with Transform Y of Fire object ?
    public bool CanRotateGun(float verticalInput)
    {
        float gunRotationVertical = gunPositionObject.transform.rotation.eulerAngles.x;

        //UP
        if (gunRotationVertical > 300 && gunRotationVertical < 360) {
            // up
            if (verticalInput > 0 && gunRotationVertical > 310) {
                return true;
            }

            // down
            if (verticalInput < 0) {
                return true;
            }
        } else {
            // up
            if (verticalInput > 0) {
                return true;
            }

            // down
            if (gunRotationVertical < 6) {
                return true;
            }
        }

        return false;
    }
}
