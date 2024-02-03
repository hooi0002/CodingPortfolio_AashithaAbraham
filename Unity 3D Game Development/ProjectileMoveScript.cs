using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script defines the action/behaviour of a projectile clone

public class ProjectileMoveScript : MonoBehaviour
{
    public float fireRate;
    public float speed;
    public float accuracy;
    private float inaccuracy;
    public float damage = 20f;

    public bool rotate = false;
    public float rotateAmount = 45f;
    public bool bounce = false;
    public float bounceForce = 10f;
    private Rigidbody rb;
    private bool collided;

    private Vector3 startPos;
    private Vector3 offset;

    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

        // To implement point accuracy logic
        if (accuracy != 100)
        {
            inaccuracy = 1 - (accuracy / 100);

            for (int i = 0; i < 2; i++)
            {
                var val = 1 * Random.Range(-inaccuracy, inaccuracy);
                var index = Random.Range(0, 2);

                // if this is the first for loop iteration
                if (i == 0)
                {
                    if (index == 0)
                    {
                        offset = new Vector3(0, val, 0);
                    }else
                    {
                        offset = new Vector3(0, -val, 0);
                    }
                } else // if this is the second for loop iteration
                {
                    if (index == 0)
                    {
                        offset = new Vector3(0, offset.y, -val);
                    }else
                    {
                        offset = new Vector3(0, offset.y, val);
                    }
                }
            }
        }

        // Spawn a muzzle flash prefab clone here
        if (muzzlePrefab != null)
        {
            // muzzleVFX represents a clone of muzzlePrefab
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);

            // To shift muzzleVFX slightly based on accuracy setting
            muzzleVFX.transform.forward = gameObject.transform.forward + offset;

            // Create a reference to all components in the muzzle flash prefab
            var ps = muzzleVFX.GetComponent<ParticleSystem>();

            // Despawn muzzleVFX here
            if(ps != null)
            {
                Destroy(muzzleVFX, ps.main.duration);
            } else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }

    }

    // The update function runs exactly once every frame
    /* whereas the FixedUpdate function runs at a fixed interval
    independent of your game's frame rate, making it possible to run once,
    zero, or multiple times per frame
    */
    void FixedUpdate()
    {
        // Moving the bullet projectile clone forward
        if (speed != 0 && rb != null)
        {
            rb.position += (transform.forward + offset) * (speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // col represents an object in collision with a projectile clone
        if(!bounce)
        {
            // To ensure col is not a bullet clone
            // and the bullet clone is not already in collision
            if(col.gameObject.tag != "Bullet" && !collided)
            {
                collided = true;
                speed = 0;
                GetComponent<Rigidbody>().isKinematic = true;

                // Record point of intersection
                ContactPoint contact = col.contacts[0];

                // Record the angle and orientation of penatration
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);

                // Converts point of intersection to xyz coordinate
                Vector3 pos = contact.point;

                // Spawn hit prefab here
                if(hitPrefab != null)
                {
                    // Create a variable to hold the generated clone
                    var hitVFX = Instantiate(hitPrefab, pos, rot) as GameObject;

                    // Identify all ps in the hit prefab clone
                    var ps = hitVFX.GetComponent<ParticleSystem>();

                    //Despawn hitVFX here
                    if(ps != null)
                    {
                        Destroy(hitVFX, ps.main.duration);
                    } else
                    {
                        var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                        Destroy(hitVFX, psChild.main.duration);
                    }
                }
            }
        }

        if (col.gameObject.tag == "Zombie")
        {
            col.gameObject.GetComponent<EnemyHitBox>().OnHit(this);
        }

        Destroy(gameObject);
    }

}
