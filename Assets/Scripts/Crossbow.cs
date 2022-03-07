using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crossbow : MonoBehaviour
{
    [SerializeField] CrossbowRotating rotationSystem;
    [SerializeField] CrossbowShooting shootingSystem;

    void Update()
    {
        shootingSystem.HandleTimeShooting();
        if (!Touchscreen.current.primaryTouch.press.isPressed) { return; }
        rotationSystem.HandleRotating();
        shootingSystem.HandleShooting();
    }
}
