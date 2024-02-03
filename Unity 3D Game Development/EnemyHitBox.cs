using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    public void OnHit(ProjectileMoveScript projectile)
    {
        enemyHealth.TakeDamage(projectile.damage);
    }

    public void OnHit_Grenade(float grenadeDamage)
    {
        enemyHealth.TakeDamage(grenadeDamage);
    }
}
