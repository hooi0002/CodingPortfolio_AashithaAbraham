using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ParticleSystem muzzleFlash;

    public float range = 100f;
    public Transform shootPoint;
    public GameObject bulletImpact;
    public GameObject hitParticles;

    public float fireRate = 0.5f; //The delay between each shot
    private float fireTimer; //Time counter for the delay

    public int bulletsPerMag = 10;
    public int bulletLeft = 10; //The ammo count in inventory
    public int currentBullets; //The ammo count in the current magazine

    // Create a reference to UIManager class
    private UIManager _uiManager;

    // sniper scope
    public Animator anim;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;
    public float scopedFOV = 15f; // normal FOV is 60
    private float normalFOV;
    private bool scoped = false;

    // Dealing damage
    public float RifleDamage = 20f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentBullets = bulletsPerMag;
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
            {
                Fire();
            } else 
            {
                Reload();
            }
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }

        // Activate sniper scope if RMB is pressed
        if (Input.GetButtonDown("Fire2"))
        {
            scoped = !scoped;
            anim.SetBool("IsScoped", scoped);

            if (scoped)
            {
                StartCoroutine(OnScoped());
            } else
            {
                OnUnScoped();
            }
        }

        _uiManager.UpdateAmmo(currentBullets, bulletLeft);
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        scopeOverlay.SetActive(true);

        // Deactivate weapon cam to hide the rifle
        weaponCamera.SetActive(false);

        // Adjust FOV
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    public void OnUnScoped()
    {
        scopeOverlay.SetActive(false);

        // Activate weapon cam to show the rifle
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFOV;
    }

    private void Reload()
    {
        if(bulletLeft <= 0) return;

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletLeft >= bulletsToLoad) ? bulletsToLoad : bulletLeft;

        // Update overall bullet inventory
        bulletLeft -= bulletsToDeduct;

        //Update maganize bullet count
        currentBullets += bulletsToDeduct;
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;

        // "hit" variable stores infos about the collision between raycast and a distant collider 
        RaycastHit hit;

        // Log a message when the raycast hits sth
        if  (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " found!");

            // Spawn a bullet impact clone at where the raycast lands
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

            // Destroy bulet impact and hitSparks clones here
            Destroy(bulletHole, 2f);
            Destroy(hitParticleEffect, 1f);

            // Deal damage here
            // 1. Check if the object got hit has the HealthCOntroller script
            // 2. If true, apply damage
            if (hit.transform.GetComponent<HealthController>())
            {
                hit.transform.GetComponent<HealthController>().ApplyDamage(RifleDamage);
            }
        }

        muzzleFlash.Play();
        fireTimer = 0.0f;
        currentBullets--; 
    }
}
