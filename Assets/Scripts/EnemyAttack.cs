using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    public EnemySight sight;
    public PlayerHealth playerHealth;
    public NavMeshAgent agent;
    public float attackRange = 2f;

    void Update()
    {
        if (sight != null && sight.playerInSight && playerHealth != null)
        {
            float distance = Vector3.Distance(transform.position, sight.player.position);

            // Move toward player
            if (distance > attackRange)
            {
                agent.SetDestination(sight.player.position);
            }
            else
            {
                agent.SetDestination(transform.position); // Stop moving

                // Attack with cooldown
                if (Time.time > lastAttackTime + attackCooldown)
                {
                    playerHealth.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
