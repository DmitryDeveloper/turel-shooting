using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject airExplosionParticlePrefab;
    [SerializeField] GameObject blackSmoreParticlePrefab;
    [SerializeField] GameObject explosionParticlePrefab;

    protected void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void destroy()
    {
        if (gameObject.CompareTag("Enemy")) {
            destroyAuto();
        } 

        if (gameObject.CompareTag("AirEnemy")) { 
            destroyAir();
        }

        Destroy(gameObject);
        gameManager.UpdateCount(1);   
    }

    public void destroyAuto()
    {
        GameObject explosionParticle = Instantiate(explosionParticlePrefab, gameObject.transform.position, Quaternion.identity);
        ParticleSystem explosionParticleSystem = explosionParticle.GetComponent<ParticleSystem>();
        explosionParticleSystem.Play();

        GameObject blackSmokeParticle = Instantiate(blackSmoreParticlePrefab, gameObject.transform.position, Quaternion.identity);
        ParticleSystem blackSmokeParticleSystem = blackSmokeParticle.GetComponent<ParticleSystem>();
        blackSmokeParticleSystem.Play();
    }

    public void destroyAir()
    {
        GameObject airExplosionParticle = Instantiate(airExplosionParticlePrefab, gameObject.transform.position, Quaternion.identity);
        ParticleSystem airExplosionParticleSystem = airExplosionParticle.GetComponent<ParticleSystem>();
        airExplosionParticleSystem.Play();
    }
}
