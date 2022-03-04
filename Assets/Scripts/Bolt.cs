using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }
}
