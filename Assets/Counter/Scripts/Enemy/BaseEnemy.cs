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
    [SerializeField] int ScoreValue = 5;

    protected bool isDestroyed = false;

    protected void Start()
    {
        initEnemyAudio();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    protected void Update()
    {
        audioSource.volume = GetEnemyVolume();
    }

    protected float GetExplosionVolume()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float maxDistance = 80f;
        float volume = Mathf.Clamp(1f - (distance / maxDistance), 0f, 1f);
        return volume;
    }

    protected float GetEnemyVolume()
    {
        float maxDistance = 20f;

        if (gameObject.CompareTag("AirEnemy")) {
            maxDistance = 40f;
        }

        if (gameObject.CompareTag("Robot")) {
            maxDistance = 10f;
        }

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float volume = Mathf.Clamp(0.8f - (distance / maxDistance), 0f, 0.8f);

        return volume;
    }

    public void DoDestroy()
    {
        if (isDestroyed) {
            return;
        }

        isDestroyed = true;
        audioSource.Stop();

        StartCoroutine(DestroyWithDelay());

        audioSource.volume = GetExplosionVolume();
        audioSource.PlayOneShot(explosionAudioClip);

        if (gameObject.CompareTag("Enemy")) {
            destroyAuto();
        } 

        if (gameObject.CompareTag("AirEnemy")) { 
            destroyAir();
        }

        if (gameObject.CompareTag("Robot")) { 
            destroyRobot();
        }

        gameManager.UpdateCount(1); 
        gameManager.UpdateScore(ScoreValue);     
    }

    IEnumerator DestroyWithDelay()
    {
        float waitTime = 1.1f;

         if (gameObject.CompareTag("Robot")) { 
            waitTime = 0.3f;
        }

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    public void destroyRobot()
    {
        Vector3 explosionPosition = gameObject.transform.position;
        explosionPosition.y = 0.3f;

        GameObject explosionParticle = Instantiate(explosionParticlePrefab, explosionPosition, Quaternion.identity);
        ParticleSystem explosionParticleSystem = explosionParticle.GetComponent<ParticleSystem>();
        explosionParticleSystem.Play();
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

        // do I need that?
        // Rigidbody playerRb = GetComponent<Rigidbody>();
        // playerRb.useGravity = true;
    }

    private void initEnemyAudio()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GetEnemyVolume();
        audioSource.Play();
    }
}
