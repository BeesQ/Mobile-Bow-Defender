using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void HandleTimeShooting()
    {
        if (currentTimeBetweenShots <= timeBetweenShots) { currentTimeBetweenShots += Time.deltaTime; }
    }

    public void HandleShooting()
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
