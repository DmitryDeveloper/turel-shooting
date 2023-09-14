using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : BaseProjectile
{
    [SerializeField] float speed = 40.0f;

    private Rigidbody projectibleRb;
    private GameManager gameManager;

    public ParticleSystem dirtParticle;

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
            Debug.Log(dirtParticle);
            Debug.Log(collision.contacts[0].point);
            dirtParticle.transform.position = collision.contacts[0].point; // Устанавливаем позицию эффекта
            //TODO replace with new object to play effect?
            dirtParticle.Play(); // Запускаем эффект
            Invoke("DeactivateGameObject", 0.5f);
            return;
        }

        gameObject.SetActive(false);
    }

    private void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
