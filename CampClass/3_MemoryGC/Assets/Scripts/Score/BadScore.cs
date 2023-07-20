using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadScore : MonoBehaviour
{
    public Text ScoreText;
    public int Score;

    private string _scoreStr;

    private void Start()
    {
        Score = 99999;
    }

    private void Update()
    {
        if(ScoreText != null)
        {
            _scoreStr = "Score: " + Score.ToString();
            ScoreText.text = _scoreStr;
        }
    }
}
