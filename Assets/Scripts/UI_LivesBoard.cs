using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LivesBoard : MonoBehaviour
{
    [SerializeField]
    private Button _lifeIcon;

    private List<Button> _lifeIcons;
    private int _currentLifeCount;
    private int _oldLifeCount;


    // On start, get number of lives from game manager and player life icons to display, assigned in prefab

    private void Start()
    {
        InitializeLivesBoard();
        StartingLives();
    }

    private void Update()
    {
        UpdateRemainingLives();
    }

    // _oldLifeCount is the gate to update player lives and break out of while loops
    private void UpdateRemainingLives()
    {
        _currentLifeCount = GameManager.manager.playerLives;

        if (_oldLifeCount != _currentLifeCount)
        {
            // player gains a life
            while (_currentLifeCount > _oldLifeCount)
            {
                var icon = Instantiate(_lifeIcon, gameObject.transform);
                _lifeIcons.Add(icon);
                _oldLifeCount++;
            }
            // player loses a life
            while (_currentLifeCount < _oldLifeCount)
            {
                Destroy(_lifeIcons[0].gameObject);
                _lifeIcons.RemoveAt(0);
                _oldLifeCount--;
            }
        }
        _oldLifeCount = _currentLifeCount;
    }

    // Instantiates life icons on Start
    private void StartingLives()
    {
        while (_lifeIcons.Count < _currentLifeCount)
        {
            _lifeIcons.Add(Instantiate(_lifeIcon, gameObject.transform));
        }
    }

    private void InitializeLivesBoard()
    {
        _lifeIcons = new List<Button>();
        _currentLifeCount = GameManager.manager.playerLives;
        _oldLifeCount = _currentLifeCount;
    }
}
