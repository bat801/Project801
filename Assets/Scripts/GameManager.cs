using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText; // Ссылка на текст в UI

    private int totalCoins;

    void Start()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        UpdateUI(); // Метод, который обновит текст на экране
    }

    // Метод, который мы будем вызывать из скрипта врага
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", totalCoins); // Сохраняем
        PlayerPrefs.Save(); // Принудительно записываем на диск
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Монеты: " + totalCoins;
    }
}
