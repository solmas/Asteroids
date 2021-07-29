using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public int playerScore;
    public int playerLives;
    public GameObject player;
    public int enemyObjectId;

    private void Awake()
    {
        manager = this;
    }

    private void Start()
    {
        playerScore = 0;
        playerLives = 5;
        SpawnPlayer();
    }

    // subscribe
    private void OnEnable()
    {
        GameEvents.events.onEnemyDeath += UpdateScore;
        GameEvents.events.onPlayerDeath += UpdatePlayerLives;

    }

    // unsubscribe
    private void OnDisable()
    {
        GameEvents.events.onEnemyDeath -= UpdateScore;
        GameEvents.events.onPlayerDeath -= UpdatePlayerLives;
    }

    public void UpdateScore(int pointValue)
    {
        playerScore += pointValue;
    }

    public void UpdatePlayerLives(int life)
    {
        playerLives += life;
        if (life == -1)
        {
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(3);
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerLives >= 0)
        {
            Instantiate(player);
            GameEvents.events.PlayerSpawn();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
