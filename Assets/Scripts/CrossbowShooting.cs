using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowShooting : MonoBehaviour
{
    [SerializeField] GameObject boltPrefab;
    [SerializeField] Transform shootTransform;
    [SerializeField] float timeBetweenShots = 2f;

    [Header("Bolt Stats")]
    public float projectileSpeed = 5f;
    public float lifetime = 5f;

    public int Damage { get => damage; set => damage = value; }
    [SerializeField] private int damage = 1;

    public int Pierce { get => pierce; set => pierce = value; }
    [SerializeField] private int pierce = 1;


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
        var bolt = Instantiate(boltPrefab, shootTransform.position, transform.rotation).GetComponent<Bolt>();
        // bolt.GetComponent<Bolt>().PassStats(projectileSpeed, lifetime, Damage, Pierce);
        bolt.GetComponent<Bolt>().Pierce = Pierce;
        bolt.GetComponent<Bolt>().Damage = Damage;
    }

    // public float GetTimeBetweenShots() => timeBetweenShots;
}
