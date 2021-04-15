using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;
    private int totalScore;
    private int scoreIncrease;

    void Start()
    {
        scoreTxt.text = totalScore.ToString();
    }

    public void AddScore(GameLevelEnums.QuestionDifficultyLevel difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case GameLevelEnums.QuestionDifficultyLevel.EASY:
                scoreIncrease = 2;
                break;
            case GameLevelEnums.QuestionDifficultyLevel.MEDIUM:
                scoreIncrease = 3;
                break;
            case GameLevelEnums.QuestionDifficultyLevel.HARD:
                scoreIncrease = 4;
                break;
        }

        totalScore += scoreIncrease;
        scoreTxt.text = totalScore.ToString();
    }
}
