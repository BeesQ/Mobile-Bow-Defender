using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour, IDamageable<int>
{
    [SerializeField] GameObject deathVFX;

    float projectileSpeed = 5f;
    float lifetime = 5f;

    public int Damage { get => damage; set => damage = value; }
    int damage = 1;

    public int Pierce { get => pierce; set => pierce = value; }
    int pierce = 1;


    private void Start()
    {
        if (lifetime > 0) { StartCoroutine(StartDestroyingProjectile()); }
    }

    private void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    // public void PassStats(float myProjectileSpeed = 5f, float myLifetime = 5f, int myDamage = 1, int myPierce = 1)
    // {
    //     projectileSpeed = myProjectileSpeed;
    //     lifetime = myLifetime;
    //     damage = myDamage;
    //     pierce = myPierce;
    // }

    private IEnumerator StartDestroyingProjectile()
    {
        yield return Helpers.GetWaitInSeconds(lifetime);
        Kill();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Player Projectile")) { return; }

        var damageableObject = collider.GetComponentInParent<IDamageable<int>>();
        if (damageableObject == null) { return; }

        Instantiate(deathVFX, transform.position, Quaternion.identity);
        damageableObject.TakeDamage(Damage);
        TakeDamage(1);
    }

    public void TakeDamage(int amount)
    {
        Pierce -= amount;
        if (Pierce <= 0) { Kill(); }
    }

    private void Kill()
    {
        // Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
