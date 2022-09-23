using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    private void OnEnable()
    {
        var height = FindObjectOfType<GameController>().GetMaxHeight();

        scoreText.text = Mathf.Floor(height).ToString();

        string max = PlayerPrefs.GetString("MaxScore", "0");
        long maxScore = (long)float.Parse(max);

        if (Mathf.Floor(height) > maxScore) 
        {
            PlayerPrefs.SetString("MaxScore", height.ToString());
            maxScore = (long)height;
        }

        maxScoreText.text = maxScore.ToString();
    }
}
