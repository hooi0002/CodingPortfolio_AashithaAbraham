using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    public float maxHealth;
    public float currentHealth;
    public UnityEngine.AI.NavMeshAgent zombieAI;

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        zombieAI = GetComponent<UnityEngine.AI.NavMeshAgent>();

        currentHealth = maxHealth;
        var rigidBodies = GetComponentsInChildren<Rigidbody>();

        foreach (var rigidBody in rigidBodies)
        {
            // Assign EnemyHitBox and EnemyHealth script to every single rigidBody
            EnemyHitBox enemyHitBox = rigidBody.gameObject.AddComponent<EnemyHitBox>();

            enemyHitBox.enemyHealth = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.value = currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            anim.SetTrigger("death");
            zombieAI.speed = 0.0f;
            GetComponent<Collider>().enabled = false;

            //update the position
            transform.position = transform.position + new Vector3(0, -10, 0);

            //Destroy(gameObject);
        }
    }
}
