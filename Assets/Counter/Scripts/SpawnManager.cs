using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] vehicleEnemyPrefabs;

    private float spawnRange = 9;

    public int waveNumber = 1;

    [SerializeField] int missionWaveNumber = 3;

    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        //TODO should be singleton?
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnableReadyEvery10Seconds());
    }

    void SpawnEnemyWave(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++) {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            SpawnEnemy(enemyPrefabs[randomIndex], "air");

            SpawnEnemy(vehicleEnemyPrefabs[randomIndex], "vehicle");
        }
    }

    private void SpawnEnemy(GameObject GameObject, string EnemyType)
    {
        if (EnemyType == "air") {
            Instantiate(GameObject, GenerateAirSpawnPosition(), GameObject.transform.rotation);
        } else {
            Instantiate(GameObject, GenerateLandSpawnPosition(), GameObject.transform.rotation);
        }
    }

    private IEnumerator EnableReadyEvery10Seconds()
    {
        while (waveNumber <= missionWaveNumber) // Запускаем бесконечный цикл сопрограммы.
        {
            Debug.Log("new wave");
            SpawnEnemyWave(waveNumber);
            waveNumber++;

            // Ждем 10 секунд.
            yield return new WaitForSeconds(10f);
        }

        GameManager.LastWaveNotification();
    }

    Vector3 GenerateAirSpawnPosition()
    {
        float spawnPosX = Random.Range(-100, -110);
        float spawnPosZ = Random.Range(-20, 20);
        float spawnPosY = Random.Range(2, 16);
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    Vector3 GenerateLandSpawnPosition()
    {
        float spawnPosX = Random.Range(-100, -110);
        float spawnPosZ = Random.Range(-20, 20);
        float spawnPosY = 0.5f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
