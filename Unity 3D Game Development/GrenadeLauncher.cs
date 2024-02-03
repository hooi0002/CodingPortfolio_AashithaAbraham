using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip shootSound;

    public float range = 200f;

    public Transform shootPoint;

    public float fireRate = 0.5f;
    public float fireTimer;

    public float despawnTime = 3.0f;
    public GameObject shootingProjectile;
    public int projectileSpeed;
    public float damage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger the shots
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }

        // To increment fireTimer
        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void Fire()
    {
        // Check if enough time has passed since the last time we fired a shot
        if (fireTimer < fireRate) return;

        // "hit" variable stores all infos about the raycast
        // e.g., whether or not it collides into a game object and returns the point of collision
        RaycastHit hit;

        // Create a clone of the grenade projectile prefab
        GameObject grenade = Instantiate(shootingProjectile, shootPoint.position, shootPoint.rotation);

        // Apply physics (gravity and rigidbody collision)
        grenade.GetComponent<Rigidbody>().velocity = grenade.transform.forward * projectileSpeed;

        // Destroy the clone
        Destroy(grenade, despawnTime);

        _AudioSource.clip = shootSound;
        _AudioSource.Play();

        // Reset the counter right after a shot has been fired
        fireTimer = 0.0f;
    }
}
