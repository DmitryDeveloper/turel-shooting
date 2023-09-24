using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile
{
    [SerializeField] float speed = 40.0f;

    private Rigidbody projectibleRb;
    private GameManager gameManager;
    [SerializeField] GameObject dirtParticlePrefab;
    [SerializeField] GameObject blackSmoreParticlePrefab;
    [SerializeField] GameObject airExplosionParticlePrefab;
    [SerializeField] GameObject explosionParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        projectibleRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("AirEnemy")) {
            collision.gameObject.GetComponent<BaseEnemy>().DoDestroy();
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
