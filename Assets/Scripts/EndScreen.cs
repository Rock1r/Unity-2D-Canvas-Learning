using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private Button _replayButton;
    private Score _score;

    private void Awake()
    {
        _score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        _finalScoreText.text = "Congratulations!\nYour score is: " + _score.CalculateScore() + "%";
    }
}
