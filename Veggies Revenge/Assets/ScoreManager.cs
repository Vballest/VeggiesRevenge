using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;
    public TextMeshProUGUI ScoreTXT;

    public void updateScore(int _score = 10)
    {
        totalScore += _score;
        ScoreTXT.text = totalScore.ToString();
    }
}
