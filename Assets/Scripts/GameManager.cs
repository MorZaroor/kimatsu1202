using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.GetScore().ToString();
    }
}
