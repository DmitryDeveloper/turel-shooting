using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO should be singleton?
public class GameManager : MonoBehaviour
{
    [SerializeField] Text CounterText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text CounterNotDestroyedEnemiesText;
    [SerializeField] GameObject GameOverUIContainer; 
    [SerializeField] GameObject MissionCompletedUIContainer; 

    public bool isGameActive { get; private set; }
    private int Count = 0;
    private int Score = 0;
    private int CountNotDestroyedEnimies = 0;

    private void Start()
    {
        Count = 0;
        isGameActive = true;

        GameOverUIContainer.SetActive(false);
        MissionCompletedUIContainer.SetActive(false);
    }

    public void UpdateCount(int value)
    {
        Count += value;
        CounterText.text = "Count : " + Count;
        ScoreText.text = "Score : " + Count;
    }

    public void UpdateScore(int value)
    {
        Score += value;
        ScoreText.text = "Score : " + Score;
    }

    public void UpdateCountNotDestroyedEnemies(int value)
    {
        Debug.Log(value);
        CountNotDestroyedEnimies += value;
        CounterNotDestroyedEnemiesText.text = "Not destroyed: " + CountNotDestroyedEnimies;

        if (CountNotDestroyedEnimies > 5) {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        GameOverUIContainer.SetActive(true);
    }

    public void LastWaveNotification()
    {
        StartCoroutine(CompleteMissionWhenEnemiesAllDestroyed());
    }

    private IEnumerator CompleteMissionWhenEnemiesAllDestroyed()
    {
        //check how much enimies are on board?
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0) // Запускаем бесконечный цикл сопрограммы.
        {
            // Ждем 1 секунд.
            yield return new WaitForSeconds(1f);
        }

        MissionCompleted();
    }

    public void MissionCompleted()
    {
        isGameActive = false;
        MissionCompletedUIContainer.SetActive(true);
    }
}
