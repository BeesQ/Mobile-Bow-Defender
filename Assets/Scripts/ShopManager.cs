using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] CrossbowShooting player;
    [SerializeField] EnemySpawner enemySpawner;

    public void OnPierceButtonClick()
    {
        player.Pierce += 1;
    }

    public void OnDamageButtonClick()
    {
        player.Damage += 1;
    }

    public void OnEnemyHealthButtonClick()
    {
        enemySpawner.EnemyHealth += 1;
    }
}
