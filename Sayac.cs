using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sayac : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private float timeRemaining = 121f; // Kalan zaman

    void Start()
    {
        UpdateTime(timeRemaining);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
    }

    // Zamanı güncelleyen metod
    private void UpdateTime(float timeLeft)
    {
        // Saat simgesini metin olarak ekleyerek zamanı güncelle
        timer.text = "Süre bitiyor " + Mathf.FloorToInt(timeLeft);
    }
}
