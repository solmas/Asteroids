using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public PlayerControls controls;
    public static PlayerShip playerShip;

    private float _turnThrust = 1f;
    private Rigidbody2D _rb;
    

    private void Awake()
    {
        controls = new PlayerControls();
        controls.ShipControls.Forward.started += ctx =>
        {
            _thrust = ctx.ReadValue<float>();
            isThrusting = true;
        };
        controls.ShipControls.Forward.canceled += ctx =>
        {
            _thrust = ctx.ReadValue<float>();
            isThrusting = false;
        };
        controls.ShipControls.RotateLeft.started += ctx =>
        {
            isRotatingLeft = true;
            isRotating = true;
        };
        controls.ShipControls.RotateLeft.canceled += ctx => isRotating = false;
        controls.ShipControls.RotateRight.started += ctx => 
        {
            isRotatingLeft = false;
            isRotating = true;
        };
        controls.ShipControls.RotateRight.canceled += ctx => isRotating = false;
        controls.ShipControls.Fire.performed += ctx => Fire();

        torpedoSpawnPoint = gameObject.GetComponentInChildren<Transform>().gameObject;

    }

    private void OnEnable()
    {
        controls.Enable();
        GameEvents.events.onPlayerSpawn += PlayerInvincibility;
    }

    private void OnDisable()
    {
        controls.Disable();
        GameEvents.events.onPlayerHit -= PlayerHit;
        GameEvents.events.onPlayerSpawn -= PlayerInvincibility;
    }

    private void Start()
    {
        playerShip = this;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        GameEvents.events.onPlayerHit += PlayerHit;
    }

    private void Update()
    {
        ForwardThrust();
        RotateThrust();
    }

    #region Player Controls
    public bool isThrusting = false;
    public float _thrust = 10;
    private void ForwardThrust()
    {
        if (isThrusting)
        {
            _rb.AddRelativeForce(Vector2.up * (_thrust));
        }
    }

    public bool isRotating = false;
    public bool isRotatingLeft;
    public float turnPower;

    private void RotateThrust()
    {
        if (isRotating)
        {
            if (isRotatingLeft)
            {
                _rb.AddTorque(_turnThrust * turnPower);
            }
            else if (!isRotatingLeft)
            {
                _rb.AddTorque(_turnThrust * -turnPower);
            }
        }
    }

    [SerializeField]
    private GameObject photonTorpedo;
    private GameObject torpedoSpawnPoint;
    private void Fire()
    {
        var torpedo = Instantiate(photonTorpedo, torpedoSpawnPoint.transform.position, torpedoSpawnPoint.transform.rotation);
        torpedo.GetComponent<PhotonTorpedo>().OnFire();
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" || collision.tag == "asteroid")
        {
            Debug.Log($"Player hit by {collision.gameObject.name}");

            PlayerHit();
        }
        if (collision.tag == "life")
        {
            PlayerGainedLife();
        }
    }

    public void PlayerHit()
    {
        // do local hit stuff and then
        PlayerDeath();
    }

    public void PlayerDeath()
    {
        var life = -1;
        GameEvents.events.PlayerDeath(life);

        // do local death stuff
        gameObject.GetComponent<PositionWrapping>().DestroyGhosts();
        Destroy(gameObject);
    }

    public void PlayerGainedLife()
    {
        var life = 1;
        GameEvents.events.PlayerDeath(life);
    }

    public float InvincibilityTime = 3f;
    public float FlashFrequency = .1f;
    // Disables player collider, sets SpriteRenderer and sets tmp1 and tmp2 as alpha values 0 and 1
    private void PlayerInvincibility()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        
        StartCoroutine(InvincibilityTimer());
        InvokeRepeating("InvincibilityFlash", .01f, FlashFrequency);
    }

    private void InvincibilityFlash()
    {
        var renderer = gameObject.GetComponent<SpriteRenderer>();
        var tmp1 = renderer.color;
        var tmp2 = renderer.color;
        tmp1.a = 0f;
        tmp2.a = 1f;
        renderer.color = tmp1;

        if (renderer.color == tmp1)
        {
            LeanTween.alpha(renderer.gameObject, 1f, FlashFrequency).setEaseInSine();
        }
        else
        {
            LeanTween.alpha(gameObject, 0f, FlashFrequency).setEaseOutSine();
        }
    }

    private IEnumerator InvincibilityTimer()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        CancelInvoke("InvincibilityFlash");
    }

}
