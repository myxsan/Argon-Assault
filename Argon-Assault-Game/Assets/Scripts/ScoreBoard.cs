using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;

    private void Awake() {
        scoreText = GetComponent<TMP_Text>();
    }
    private void Update() {
        SetScore();
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
    }

    void SetScore()
    {
        if (scoreText.text != score.ToString("000000000"))
        {
            scoreText.text = score.ToString("000000000");
        }
    }
}
