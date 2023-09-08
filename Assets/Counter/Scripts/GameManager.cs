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
    [SerializeField] Text CounterNotDestroyedEnemiesText;
    [SerializeField] GameObject GameOverUIContainer; 

    public bool isGameActive { get; private set; }
    private int Count = 0;
    private int CountNotDestroyedEnimies = 0;

    private void Start()
    {
        Count = 0;
        isGameActive = true;

        GameOverUIContainer.SetActive(false);
    }

    public void UpdateCount(int value)
    {
        Count += value;
        CounterText.text = "Count : " + Count;
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
}
