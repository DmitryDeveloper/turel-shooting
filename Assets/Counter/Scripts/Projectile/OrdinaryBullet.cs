using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile
{
    [SerializeField] float speed = 40.0f;

    private Rigidbody projectibleRb;
    private GameManager gameManager;
    public GameObject dirtParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        projectibleRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            gameManager.UpdateCount(1);
        }

        if (collision.gameObject.CompareTag("Ground")) {
            GameObject newDirtParticle = Instantiate(dirtParticlePrefab, collision.contacts[0].point, Quaternion.Euler(-100, 90, 0));
            ParticleSystem newDirtParticleSystem = newDirtParticle.GetComponent<ParticleSystem>();
            newDirtParticleSystem.Play();

            Destroy(newDirtParticle, newDirtParticleSystem.main.duration);
        }

        gameObject.SetActive(false);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
