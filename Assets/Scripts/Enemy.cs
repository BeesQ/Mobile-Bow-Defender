using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable<float>
{
    [SerializeField] float health = 1f;
    [SerializeField] GameObject deathVFX;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0) { Kill(); }
    }

    void Kill()
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
