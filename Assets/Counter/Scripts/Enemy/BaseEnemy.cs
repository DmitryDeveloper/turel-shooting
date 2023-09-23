using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject airExplosionParticlePrefab;
    [SerializeField] GameObject blackSmoreParticlePrefab;
    [SerializeField] GameObject explosionParticlePrefab;
    private AudioSource audioSource;
    [SerializeField] AudioClip explosionAudioClip;

    // private float explosionVolume;

    protected bool isDestroyed = false;

    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected float GetExplosionVolume()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float maxDistance = 80f;
        float volume = Mathf.Clamp(1f - (distance / maxDistance), 0f, 1f);
        return volume;
    }

    public void destroy()
    {
        if (isDestroyed) {
            return;
        }

        StartCoroutine(DestroyWithDelay());
        isDestroyed = true;

        audioSource.PlayOneShot(explosionAudioClip, GetExplosionVolume());

        if (gameObject.CompareTag("Enemy")) {
            destroyAuto();
        } 

        if (gameObject.CompareTag("AirEnemy")) { 
            destroyAir();
        }

        gameManager.UpdateCount(1);   
    }

    IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
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
