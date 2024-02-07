using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToCompleteQuestion = 30f;
    [SerializeField] private float _timeToShowCorrectAnswer = 5f;

    private float _timerValue;

    public float _fillFraction;
    public bool _loadNextQuestion = false;
    public bool _isAnsweringQuestion = false;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if(_isAnsweringQuestion)
        {
            if (_timerValue > 0)
            {
                _fillFraction = _timerValue / _timeToCompleteQuestion;
            }
            else
            {
                _timerValue = _timeToShowCorrectAnswer;
                _isAnsweringQuestion = false;
            }
        }
        else
        {
            if (_timerValue > 0)
            {
                _fillFraction = _timerValue / _timeToShowCorrectAnswer;
            }
            else
            {
                _timerValue = _timeToCompleteQuestion;
                _isAnsweringQuestion = true;
                _loadNextQuestion = true;
            }
        }
    }
}
