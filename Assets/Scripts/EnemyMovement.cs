using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] bool isMoving = true;
    [SerializeField] float speed = 5f;

    public void HandleMovement()
    {
        if (!isMoving) { return; }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
