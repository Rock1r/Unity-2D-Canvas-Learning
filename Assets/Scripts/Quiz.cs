using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Reflection;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private QuestionSO _question;
    [SerializeField] private GameObject[] _answerButtons;
    [SerializeField] private Sprite _defaultButtonSprite;
    [SerializeField] private Sprite _correctButtonSprite;
    int _correctAnswerIndex;

    void Start()
    {
        DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == _question.GetCorrectAnswerIndex())
        {
            buttonImage = _answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = _correctButtonSprite;
            _questionText.text = "Correct!";
        }
        else
        {
            _correctAnswerIndex = _question.GetCorrectAnswerIndex();
            string correctAnswer = _question.GetAnswer(_correctAnswerIndex);
            _questionText.text = "Sorry, the correct answer is:\n" + correctAnswer;
            buttonImage = _answerButtons[_correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = _correctButtonSprite;
        }
        SetButtonsState(false);
    }

    private void GetNextQuestion()
    {
        SetButtonsState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        _questionText.text = _question.GetQuestion();

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _question.GetAnswer(i);
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
