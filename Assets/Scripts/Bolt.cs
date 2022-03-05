using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float lifetime = 5f;

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
}
