using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour, IDamageable<float>
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float lifetime = 5f;
    [SerializeField] float damage = 1f;
    [SerializeField] float pierce = 1f;

    private void Awake()
    {
        if (lifetime > 0) { StartCoroutine(DestroyProjectile()); }
    }

    private void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyProjectile()
    {
        yield return Helpers.GetWaitInSeconds(lifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Player Projectile")) { return; }

        var damageableObject = collider.GetComponent<IDamageable<float>>();
        damageableObject.TakeDamage(damage);
        TakeDamage(1);
    }


    public void TakeDamage(float amount)
    {
        pierce -= amount;
        if (pierce <= 0) { Destroy(gameObject); }
    }
}
