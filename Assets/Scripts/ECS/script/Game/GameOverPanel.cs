﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private Color victoryColor;
    [SerializeField] private Color failedColor;
    [SerializeField] private GameObject shareTip;
    [SerializeField] private GameObject shareDot;
    [SerializeField] private GameObject newScoreEffect;
    private void OnEnable()
    {
        var height = FindObjectOfType<GameController>().GetMaxHeight();

        scoreText.text = Mathf.Floor(height).ToString();

        string max = PlayerPrefs.GetString("MaxScore", "0");
        long maxScore = (long)float.Parse(max);

        if (Mathf.Floor(height) > maxScore) 
        {
            SetNewScore(true);
            SoundManager.Instance.PlaySound(SoundName.Victory);
            scoreText.color = victoryColor;
            PlayerPrefs.SetString("MaxScore", height.ToString());
            maxScore = (long)height;
        }
        else
        {
            SetNewScore(false);
            scoreText.color = failedColor;
            SoundManager.Instance.PlaySound(SoundName.Failed);
        }

        maxScoreText.text = maxScore.ToString();
    }

    public void SetNewScore(bool newScore)
    {
        if (newScore)
        {
            titleText.text = "CONGRATULATION";
            titleText.fontSize = 82;
            shareTip.SetActive(true);
            shareDot.SetActive(true);
            newScoreEffect.SetActive(true);
        }
        else
        {
            titleText.text = "GAME OVER";
            titleText.fontSize = 110;
            shareTip.SetActive(false);
            shareDot.SetActive(false);
            newScoreEffect.SetActive(false);
        }
    }
}
