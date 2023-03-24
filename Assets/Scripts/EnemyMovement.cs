using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    public void HandleMovement()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
