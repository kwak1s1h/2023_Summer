using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text ScoreText;

    private int _score;
    public int Score 
    {
        get => _score;
        set 
        {
            _score = value;
            ScoreText.text = $"Score: {_score}";
        }
    }

    private void Start()
    {
        Score = 50;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Score++;
        }
    }
}
