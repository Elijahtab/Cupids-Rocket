using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public int score;

    void Start()
    {
        scoreText.text = score.ToString();
    }
    public void increaseScore(int scoreInput)
    {
        score += scoreInput;
        scoreText.text = score.ToString();
    }
}
