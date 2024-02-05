using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Reflection;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private List<QuestionSO> _questions = new List<QuestionSO>();
    private QuestionSO _currentQuestion;

    [Header("Answers")]
    [SerializeField] private GameObject[] _answerButtons;
    private int _correctAnswerIndex;
    private bool _answerDone = false;

    [Header("Button Colors")]
    [SerializeField] private Sprite _defaultButtonSprite;
    [SerializeField] private Sprite _correctButtonSprite;

    [Header("Timer")]
    [SerializeField] private Image _timerImage;
    private Timer _timer;

    void Start()
    {
        _timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        _timerImage.fillAmount = _timer._fillFraction;
        if (_timer._loadNextQuestion)
        {
            GetNextQuestion();
            _timer._loadNextQuestion = false;
            _answerDone = false;
        }
        else if (!_answerDone && !_timer._isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonsState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        _answerDone = true;
        DisplayAnswer(index);
        SetButtonsState(false);
        _timer.CancelTimer();
    }

    private void GetNextQuestion()
    {
        if (_questions.Count > 0)
        {
            SetButtonsState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
    }

    private void GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, _questions.Count);
        _currentQuestion = _questions[index];

        if (_questions.Contains( _currentQuestion ) )
        {
            _questions.Remove(_currentQuestion);
        }
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == _currentQuestion.GetCorrectAnswerIndex())
        {
            buttonImage = _answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = _correctButtonSprite;
            _questionText.text = "Correct!";
        }
        else
        {
            _correctAnswerIndex = _currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = _currentQuestion.GetAnswer(_correctAnswerIndex);
            _questionText.text = "Sorry, the correct answer is:\n" + correctAnswer;
            buttonImage = _answerButtons[_correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = _correctButtonSprite;
        }
    }

    private void DisplayQuestion()
    {
        _questionText.text = _currentQuestion.GetQuestion();

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswer(i);
        }
    }

    private void SetButtonsState(bool state)
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            Button button = _answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

   private void SetDefaultButtonSprites()
    {
        Image buttonImage;
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            buttonImage = _answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = _defaultButtonSprite;
        }
    }
}
