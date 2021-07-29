using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : EnemyBase
{
    private void Start()
    {
        GameEvents.events.onEnemyHit += AsteroidHit;
    }

    private void OnDisable()
    {
        GameEvents.events.onEnemyHit -= AsteroidHit;
    }

    // Additional collision triggers that are not Photon Torpedos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AsteroidHit(Id);
        }
    }

    public void AsteroidHit(int id)
    {
        if (id == Id)
        {
            // do local hit stuff and then

            EnemyBaseDeath();
            AsteroidDeath();
        }
    }

    public void AsteroidDeath()
    {
        GameEvents.events.EnemyDeath(ScoreValue);

        // do local death stuff

        Destroy(gameObject);
    }
}
