using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private Color victoryColor;
    [SerializeField] private Color failedColor;
    private void OnEnable()
    {
        var height = FindObjectOfType<GameController>().GetMaxHeight();

        scoreText.text = Mathf.Floor(height).ToString();

        string max = PlayerPrefs.GetString("MaxScore", "0");
        long maxScore = (long)float.Parse(max);

        if (Mathf.Floor(height) > maxScore) 
        {
            SoundManager.Instance.PlaySound(SoundName.Victory);
            scoreText.color = victoryColor;
            PlayerPrefs.SetString("MaxScore", height.ToString());
            maxScore = (long)height;
        }
        else
        {
            scoreText.color = failedColor;
            SoundManager.Instance.PlaySound(SoundName.Failed);
        }

        maxScoreText.text = maxScore.ToString();
    }
}
