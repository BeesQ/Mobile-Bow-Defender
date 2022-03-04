using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed) { return; }
        HandleRotating();
        HandleShooting();
    }

    private void HandleRotating()
    {
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 worldPosition = Helpers.Camera.ScreenToWorldPoint(touchPosition);
        Vector2 offset = new Vector2(worldPosition.x - transform.position.x, worldPosition.y - transform.position.y);
        transform.up = offset;
    }

    private void HandleShooting()
    {
        
    }
}
