using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : EnemyBase
{

    private void Start()
    {
        GameEvents.events.onEnemyHit += EnemyShipHit;
    }

    private void OnDisable()
    {
        GameEvents.events.onEnemyHit -= EnemyShipHit;
    }

    // Additional collision triggers that are not Photon Torpedos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnemyShipHit(Id);
        }
    }

    public void EnemyShipHit(int id)
    {
        if (id == Id)
        {
            // do local hit stuff

            EnemyShipDeath();
        }
    }

   public void EnemyShipDeath()
    {
        GameEvents.events.EnemyDeath(ScoreValue);
        gameObject.GetComponent<PositionWrapping>().DestroyGhosts();
        // do local death stuff

        Destroy(gameObject);
    }
}
