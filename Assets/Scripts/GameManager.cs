using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText; // —сылка на текст в UI

    // ћетод, который мы будем вызывать из скрипта врага
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "¬рагов уничтожено: " + score;
    }
}
