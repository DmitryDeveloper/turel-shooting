using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBorder : MonoBehaviour
{
    private GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            GameManager.UpdateCountNotDestroyedEnemies(1);
        }
    }
}
