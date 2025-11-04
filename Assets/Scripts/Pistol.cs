using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Yellow ball prefab
    [SerializeField] private Transform firePoint; // Tip of the gun
    [SerializeField] private AudioClip shotClip; // Gunshot sound
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private float coolDown = 1.0f; 

    private float nextAllowedShot = 0f;

    void Update()
    {
        bool triggerPulled = Input.GetButtonDown("Fire2");
        bool canShoot = Time.time >= nextAllowedShot;

        if (triggerPulled && canShoot)
        {
            nextAllowedShot = Time.time + coolDown;
            Fire();
        }
    }

    private void Fire()
    {
        // Play gunshot sound
        if (shotClip != null)
            AudioSource.PlayClipAtPoint(shotClip, transform.position);



        // Spawn bullet
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = firePoint.forward * bulletSpeed;

            Destroy(bullet, 3f); // Clean up after 3 seconds
        }
    }
}

