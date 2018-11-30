using UnityEngine;
using System.Collections;

public class obstacleSpawner : MonoBehaviour {


    public GameObject[] obstaclePrefabs;
    public GameObject[] extraPointsPrefab;
    private int probability;
    private float randomX;
    private float randomY;
    private float randomZ;
    private Vector3 newSpawnDistance;
    private Vector3 distanceToNext;
    public int startingObstacles;
    public Transform startingSpawnDistance;


    void Start()
    {
        distanceToNext = startingSpawnDistance.transform.position;

        generateDistances();
        Spawn();
        spawnCheck();

        for (int i = 0; i < startingObstacles; i++)
        {
            generateDistances();
            Spawn();
            spawnCheck();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag=="net")
        {
            generateDistances();
            Spawn();
            Destroy(coll.transform.parent.gameObject);
        }
    }

    void generateDistances()
    {
        randomX = Random.Range(-12.2f, 12.2f);
        randomY = Random.Range(-12.5f, 13.5f);
        randomZ = Random.Range(25.0f, 26.0f);

        newSpawnDistance =new Vector3 (randomX, randomY, randomZ);
        distanceToNext += newSpawnDistance;
    }
    
    void Spawn()
    {

        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)],distanceToNext , Quaternion.identity);
        spawnCheck();

    }

    void spawnExtraPoints()
    {
        int i = Random.Range(0, extraPointsPrefab.Length);
        Instantiate(extraPointsPrefab[i], distanceToNext - new Vector3(0,0, randomZ/3),Quaternion.identity);
    }

    void spawnCheck()
    {
        probability = Random.Range(0, 5);
        if (probability == 0) 
                {
            spawnExtraPoints();
                 }
    }
}
