using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;
    public int maxHealth = 100;
    public TMP_Text healthText;
    public GameObject GameOver;

    void Start()
    {
        UpdateHealthUI();
        GameOver.SetActive(false); // Hide at start
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateHealthUI();

        if (playerHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    public void Heal(int amount)
    {
        playerHealth = Mathf.Min(playerHealth + amount, maxHealth);
        UpdateHealthUI();
        Debug.Log("Healed! Current health: " + playerHealth);
    }

    void UpdateHealthUI()
    {
        healthText.text = playerHealth.ToString();
    }

    void TriggerGameOver()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}
