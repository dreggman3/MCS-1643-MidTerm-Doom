using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public GameObject enemyRoot;

    public void ApplyDamage(int damage)
    {
        EnemyHealth health = enemyRoot.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}