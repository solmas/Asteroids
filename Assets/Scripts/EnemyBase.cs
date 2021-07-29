using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // ScoreValue is set on object prefab
    public int ScoreValue;

    // Id is set in SpawnObjects.SpawnObjectsRandomly()
    public int Id;

    private void Start()
    {
    }

    private void Update()
    {
        EnemyMovement();
    }


    private float _enemyThrust;
    private Rigidbody2D _rb;
    [SerializeField]
    private float _maxSpeed = 4f;
    [SerializeField]
    private float _minSpeed = .2f;
    
    private void EnemyMovement()
    {
        if (_rb == null)
        {
            _enemyThrust = Random.Range(_minSpeed, _maxSpeed);
            _rb = gameObject.GetComponent<Rigidbody2D>();
        }

        if (_rb.velocity.magnitude < _enemyThrust)
        {
            _rb.AddRelativeForce(Vector2.up * (_enemyThrust));
        }
    }

    public void EnemyBaseDeath()
    {
        gameObject.GetComponent<PositionWrapping>().DestroyGhosts();
    }
}
