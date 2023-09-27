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
        yield return new WaitForSeconds(100f);

        while (waveNumber <= missionWaveNumber)
        {
            Debug.Log("new wave");
            SpawnEnemyWave(waveNumber);
            waveNumber++;

            yield return new WaitForSeconds(15f);
        }

        yield return new WaitForSeconds(20f);

        waveNumber = 0;

        while (waveNumber <= missionWaveNumber)
        {
            Debug.Log("new wave");
            SpawnEnemyWave(waveNumber);
            waveNumber++;

            yield return new WaitForSeconds(10f);
        }

        GameManager.LastWaveNotification();
    }

    Vector3 GenerateAirSpawnPosition()
    {
        float spawnPosX = Random.Range(-120, -140);
        float spawnPosZ = Random.Range(-20, 20);
        float spawnPosY = Random.Range(2, 16);
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }

    Vector3 GenerateLandSpawnPosition()
    {
        float spawnPosX = Random.Range(-100, -120);
        float spawnPosZ = Random.Range(-25, 25);
        float spawnPosY = 0.5f;
        return new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    }
}
