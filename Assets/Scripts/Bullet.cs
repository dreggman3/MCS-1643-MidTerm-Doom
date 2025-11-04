using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;
    [SerializeField] private int damage = 10;

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy after a few seconds
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Bullet hit: {collision.gameObject.name}");

        // Check if the object hit has Hitbox 
        if (collision.gameObject.CompareTag("Hitbox"))
        {
            HitBox hitbox = collision.gameObject.GetComponent<HitBox>();
            if (hitbox != null)
            {
                hitbox.ApplyDamage(damage);
            }
        }

        Destroy(gameObject); // Destroy bullet on impact
    }
}
