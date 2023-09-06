using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    public void UpdateCount(int value)
    {
        Count += value;
        CounterText.text = "Count : " + Count;
    }
}
