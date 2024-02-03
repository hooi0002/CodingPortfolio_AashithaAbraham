using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public Transform firepoint;
    public List<GameObject> vfx = new List<GameObject>();
    
    private GameObject effectToSpawn;
    private float timeToFire = 0f; // For cooldown between shots

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {   
        // Ensure enough time has passed since we last fired a shot
        if(Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMoveScript>().fireRate;
            spawnVFX();
        }
    }

    void spawnVFX()
    {
        GameObject bulletClone;
        if (firepoint != null)
        {
            bulletClone = Instantiate(effectToSpawn, firepoint.position, firepoint.rotation);
        } else
        {
            Debug.Log("No fire point!");
        }
    }
}
