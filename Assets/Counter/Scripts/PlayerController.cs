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
    [SerializeField] ParticleSystem fireParticle;
    private AudioSource audioSource;
    [SerializeField] AudioClip shootAudioClip;

    private float horizontalInput;
    private float verticalInput;

    private float horizontalLeftMax = 240.0f;
    private float horizontalRightMax = 320.0f;

    private GameManager GameManager;

    void Start()
    {
        //TODO should be singleton?
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (CanRotateGun(verticalInput)) {
            gunPositionObject.transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed * verticalInput);            
        }
        
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed * horizontalInput);

        if (!GameManager.isGameActive) {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }

    private void fire()
    {
        // Get an object object from the pool
        GameObject pooledProjectile = ProjectilePooler.SharedInstance.GetPooledObject();

        if (pooledProjectile != null)
        {
            StartCoroutine("MoveGunAnimationEffect");

            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = firePositionObject.transform.position; // position it at player
            pooledProjectile.GetComponent<Rigidbody>().velocity = gunPositionObject.transform.forward * power;

            audioSource.PlayOneShot(shootAudioClip, 0.2f);

            StartCoroutine("PlayShotParticle");
        }
    }

    IEnumerator MoveGunAnimationEffect()
	{
        gunPositionObject.transform.Translate(new Vector3(0, 0, -0.1f));
		yield return new WaitForSeconds(0.1f);
        gunPositionObject.transform.Translate(new Vector3(0, 0, 0.1f));
	}

    IEnumerator PlayShotParticle()
	{
        fireParticle.Play();
		yield return new WaitForSeconds(0.1f);
		fireParticle.Stop();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            GameManager.GameOver();
            Destroy(collision.gameObject);
        }
    }
}
