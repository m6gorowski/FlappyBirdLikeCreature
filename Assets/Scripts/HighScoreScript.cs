using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highScoreText;
    private int _highScore;

    public PlayerMovementScript playerMovementScript { get; private set; }

    private void OnEnable()
    {
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();
        _scoreText.text = _scoreText.text + playerMovementScript.points.ToString();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }
        if (playerMovementScript.points >= _highScore)
        {
            _highScore = playerMovementScript.points;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        _highScoreText.text = _highScoreText.text + _highScore.ToString();
    }
}
