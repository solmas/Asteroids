using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PositionWrapping functions by creating 8 "ghosts" of the object and driving their position and rotation on the player.
// When the parent object moves out of the viewport bounds, its position is updated to that of the ghost object within view port bounds.  Then
// all ghost objects update accordingly.  DestroyGhosts is called from EnemyDeath() and PlayerDeath() methods
public class PositionWrapping : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]
    private GameObject _ghost;

    public bool spriteRendererVisible = true;

    void Start()
    {
        _mainCamera = Camera.main;
        SetScreenSize();
        CreateGhosts();
    }

    void Update()
    {
        SwapParentWithGhostPosition();
    }

    private float _screenWidth;
    private float _screenHeight;

    private void SetScreenSize()
    {
        var screenBottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        var screenTopRight = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));
        _screenWidth = screenTopRight.x - screenBottomLeft.x;
        _screenHeight = screenTopRight.y - screenBottomLeft.y;
    }

    private Transform[] _ghosts = new Transform[8];

    // Creates ghosts for parent object using _ghost object field assigned in the prefab.  All ghost prefabs will have have the suffix "Ghost"
    private void CreateGhosts()
    {
        for (int i = 0; i < 8; i++)
        {
            _ghosts[i] = Instantiate(_ghost.transform, Vector3.zero, Quaternion.identity);
        }
    }

    // Positions ghosts clockwise from Top Left of screen and sets rotation at the end
    private void PositionGhosts()
    {
        // ghostPos = current ship position
        // All 8 ghosts will spawn clockwise from top left 
        var ghostPos = gameObject.transform.position;

        // Top left
        ghostPos.x = transform.position.x - _screenWidth;
        ghostPos.y = transform.position.y + _screenHeight;
        _ghosts[0].position = ghostPos;

        // Top
        ghostPos.x = transform.position.x;
        ghostPos.y = transform.position.y + _screenHeight;
        _ghosts[1].position = ghostPos;

        // Top right
        ghostPos.x = transform.position.x + _screenWidth;
        ghostPos.y = transform.position.y + _screenHeight;
        _ghosts[2].position = ghostPos;

        // Right
        ghostPos.x = transform.position.x + _screenWidth;
        ghostPos.y = transform.position.y;
        _ghosts[3].position = ghostPos;

        // Bottom right
        ghostPos.x = transform.position.x + _screenWidth;
        ghostPos.y = transform.position.y - _screenHeight;
        _ghosts[4].position = ghostPos;

        // Bottom
        ghostPos.x = transform.position.x;
        ghostPos.y = transform.position.y - _screenHeight;
        _ghosts[5].position = ghostPos;

        // Bottom left
        ghostPos.x = transform.position.x - _screenWidth;
        ghostPos.y = transform.position.y - _screenHeight;
        _ghosts[6].position = ghostPos;

        // Left
        ghostPos.x = transform.position.x - _screenWidth;
        ghostPos.y = transform.position.y;
        _ghosts[7].position = ghostPos;

        // Set rotation to actual objects rotation
        for (int i = 0; i < 8; i++)
        {
            _ghosts[i].rotation = transform.rotation;
        }
    }

    // If parent is NOT visible on screen, check which ghost is within the viewport bounds and swap position with parent
    private void SwapParentWithGhostPosition()
    {
        if (!IsObjectVisible())
        {
            foreach (var ghost in _ghosts)
            {
                var viewPortObjPosition = _mainCamera.WorldToViewportPoint(ghost.transform.position, Camera.MonoOrStereoscopicEye.Mono);

                if (viewPortObjPosition.x > 0 && viewPortObjPosition.x < 1 &&
                    viewPortObjPosition.y > 0 && viewPortObjPosition.y < 1)
                {
                    gameObject.transform.position = ghost.position;
                    break;
                }
            }
        }
        PositionGhosts();
    }

    // Gate that checks if the parent object is visible on screen and returns bool
    private bool IsObjectVisible()
    {
        var viewPortObjPosition = _mainCamera.WorldToViewportPoint(gameObject.transform.position, Camera.MonoOrStereoscopicEye.Mono);
        
        if (viewPortObjPosition.x > 0 && viewPortObjPosition.x < 1 &&
            viewPortObjPosition.y > 0 && viewPortObjPosition.y < 1)
        {
            return true;
        }
        return false;
    }

    public void DestroyGhosts()
    {
        foreach (var ghost in _ghosts)
        {
            Destroy(ghost.gameObject);
        }
    }
}
