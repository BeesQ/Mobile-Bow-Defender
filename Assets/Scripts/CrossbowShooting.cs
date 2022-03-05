using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossbowShooting : MonoBehaviour
{
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform shootTransform;
    [SerializeField] float timeBetweenShots = 2f;

    CrossbowAnimationSystem myAnimationSystem = null;
    float currentTimeBetweenShots = 0f;
    bool isShooting = false;

    private void Awake()
    {
        currentTimeBetweenShots = timeBetweenShots;
        myAnimationSystem = GetComponent<CrossbowAnimationSystem>();
    }

    private void Update()
    {
        HandleTimeShooting();

        if (!Touchscreen.current.primaryTouch.press.isPressed) { return; }
        HandleShooting();
    }

    private void HandleTimeShooting()
    {
        if (currentTimeBetweenShots <= timeBetweenShots) {currentTimeBetweenShots += Time.deltaTime;}
    }

    private void HandleShooting()
    {
        if (currentTimeBetweenShots >= timeBetweenShots)
        {
            ShootBullet();
            currentTimeBetweenShots = 0f;
        }
    }

    private void ShootBullet()
    {
        StartCoroutine(myAnimationSystem.Shoot(timeBetweenShots - 0.5f));
        var bolt = Instantiate(boltPrefab, shootTransform.position, transform.rotation);
    }

    // public float GetTimeBetweenShots() => timeBetweenShots;
}
