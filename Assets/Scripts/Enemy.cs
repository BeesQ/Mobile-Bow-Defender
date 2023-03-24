using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour, IDamageable<int>
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] EnemyMovement movementSystem;
    [SerializeField] int health = 1;
    [SerializeField] GameObject deathVFX;

    void Start()
    {
        healthText.text = health.ToString();
    }

    void Update()
    {
        movementSystem.HandleMovement();
    }

    public void PassStats(int myHealth = 1)
    {
        health = myHealth;
        healthText.text = health.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) { Kill(); }
        healthText.text = health.ToString();
    }

    void Kill()
    {
        CameraShake.ShakeCamera(0.1f, 0.1f);
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
