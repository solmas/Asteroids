using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// GameManager is the source of truth
public class UI_ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _currentScore = 0;

    private void Start()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        UpdateScoreBoard();
    }

    private void Update()
    {
        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        _currentScore = GameManager.manager.playerScore;
        _text.text = _currentScore.ToString();
    }
}
