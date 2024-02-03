using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public GameObject[] enemies; 
    public Vector3 spawnPoints;
    public float spawnWait;
    public float spawnMaxWait;
    public float spawnMinWait;
    public int startWait;
    public bool stop = false;

    private int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitAndSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
    }

    // This function has to run in the background thread
    // Bacause it has time delay in the function
    public IEnumerator waitAndSpawn()
    {
        yield return new WaitForSeconds(startWait);
        while(!stop)
        {
            randEnemy = Random.Range(0, 2);
            Vector3 spawnPositions = new Vector3(Random.Range(spawnPoints.x, spawnPoints.x + 5), 70, Random.Range(spawnPoints.z, spawnPoints.z + 5));
            Instantiate(enemies[randEnemy], spawnPositions, gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
