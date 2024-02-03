using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncherProjectile : MonoBehaviour
{
    public float explosionRadius;
    public float explosionStrength;
    public GameObject explosionPrefab;
    public float grenadeDamage;

    private void OnCollisionEnter(Collision collider)
    {
        Instantiate(explosionPrefab, this.transform.position, transform.rotation);

        // Get a list of all nearby objects with a collider
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);

        // Iterate through each object in the colliders list
        foreach (Collider nearbyObject in colliders)
        {
            // Exert force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionStrength, transform.position, explosionRadius);
            }

            // Add Damage
            // Check if nearby object has the health controller script
            if (nearbyObject.GetComponent<HealthController>() != null)
            {
                nearbyObject.GetComponent<HealthController>().ApplyDamage(grenadeDamage);
            }

            if (nearbyObject.tag == "Zombie")
            {
                // refer to projectilemovescript for clues
                nearbyObject.GetComponent<EnemyHitBox>().OnHit_Grenade(grenadeDamage);
            }

        }

    }
}
