using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonTorpedo : MonoBehaviour
{
    private float _torpedoSpeed = 10f;
    private Rigidbody2D _rb;

    private void Update()
    {
        OnFire();
    }

    public void OnFire()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _torpedoSpeed;
        Destroy(gameObject, 3f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" || collision.tag == "asteroid")
        {
            GameEvents.events.EnemyHit(collision.GetComponent<EnemyBase>().Id);
            // Do local torpedo stuff
            Destroy(gameObject);
        }
    }
}
