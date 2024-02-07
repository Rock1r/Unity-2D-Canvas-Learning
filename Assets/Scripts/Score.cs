using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _correctAnswers = 0;
    private int _questionSeen = 0;

    public int GetCorrectAnswers()
    {
        return _correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        _correctAnswers++;
    }

    public int GetQuestionSeen()
    {
        return _questionSeen;
    }

    public void IncrementQuestionSeen()
    {
        _questionSeen++;
    }
    
    public int CalculateScore()
    {
        return Mathf.RoundToInt( _correctAnswers / (float)_questionSeen * 100 );

    }
}
