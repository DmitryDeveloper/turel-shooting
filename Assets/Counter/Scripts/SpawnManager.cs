using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    // public GameObject[] autoPrefabs;
    private float spawnRange = 9;

    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        StartCoroutine(EnableReadyEvery10Seconds());
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], GenerateSpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
        }

        waveNumber++;
    }

    private IEnumerator EnableReadyEvery10Seconds()
    {
        while (true) // Запускаем бесконечный цикл сопрограммы.
        {
            // Ждем 10 секунд.
            yield return new WaitForSeconds(15f);

            SpawnEnemyWave(waveNumber);
            Debug.Log("new wave");
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = -40.0f;
        float spawnPosZ = Random.Range(-15, 15);
        float spawnPosY = Random.Range(2, 16);
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
