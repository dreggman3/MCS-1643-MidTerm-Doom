using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int healAmount = 25;
    private bool playerInRange = false;
    private PlayerHealth player;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            playerInRange = false;
            player = null;
        }
    }
}
