using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents events;

    private void Awake()
    {
        events = this;
    }

    // Events
    public event Action<int> onEnemyDeath;
    public event Action<int> onEnemyHit;
    
    public event Action<int> onPlayerDeath;
    public event Action onPlayerHit;
    public event Action onPlayerSpawn;

    public event Action onGameOver;
    public event Action onLevelStart;

    // Event methods
    public void EnemyHit(int id)
    {
        if (onEnemyHit != null)
        {
            onEnemyHit(id);
        }
    }

    public void EnemyDeath(int scoreValue)
    {
        if (onEnemyDeath != null)
        {
            onEnemyDeath(scoreValue);
        }
    }

    public void PlayerHit()
    {
        if (onPlayerHit != null)
        {
            onPlayerHit();
        }
    }

    public void PlayerDeath(int life)
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath(life);
        }
    }

    public void PlayerSpawn()
    {
        if (onPlayerSpawn != null)
        {
            onPlayerSpawn();
        }
    }

    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }

    public void LevelStart()
    {
        if (onLevelStart != null)
        {
            onLevelStart();
        }
    }
}

