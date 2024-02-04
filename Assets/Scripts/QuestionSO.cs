using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string _question = "Enter new question text here!";
    [SerializeField] private string[] _answers = new string[4];
    [SerializeField, Range(0, 3)] private int _correctAnswerIndex;

    public string GetQuestion()
    {
        return _question;
    }

    public int GetCorrectAnswerIndex()
    {
        return _correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return _answers[index];
    }
}
