using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float detectionRange = 10f;
    public Transform player;
    public bool playerInSight;
    public float rotationSpeed = 5f; // Optional: smooth turning

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        playerInSight = distance <= detectionRange;

        if (playerInSight)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0f; // Prevent vertical rotation (DOOM-style horizontal only)

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

