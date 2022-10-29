using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawning : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public GameObject Player;
    public Transform player;
    private Timer Timer;
    private float minDistance = 2.4f;
    private float spawnRangeX = 9;
    private float spawnRangeY = 2;
    private float startDelay = 1;
    private float spawnInterval = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        Timer = GameObject.Find("Timer").GetComponent<Timer>();
        InvokeRepeating("SpawnFlower", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFlower()
    {
        int flowerIndex = Random.Range(0, flowerPrefabs.Length);
        Vector2 circlePoint = Random.insideUnitCircle.normalized * Random.Range(minDistance, minDistance+4);
        Vector2 worldPoint = player.position;
        worldPoint.x += circlePoint.x;
        worldPoint.y += circlePoint.y;

        // If the randomly chosen spawn point is within bounds, spawn it if health is greater than 0
        if ((worldPoint.x < spawnRangeX && worldPoint.x > -spawnRangeX) && (worldPoint.y < spawnRangeY && worldPoint.y > -spawnRangeY))
        {
            if (Timer.timer)
            {
                Instantiate(flowerPrefabs[flowerIndex], worldPoint, flowerPrefabs[flowerIndex].transform.rotation);
            }
        }
        // If it tries to spawn outside the allowed range, randomly choose new coordinates within ranges
        else
        {
            if (Timer.timer)
            {
                worldPoint.x = Random.Range(-spawnRangeX, spawnRangeX);
                worldPoint.y = Random.Range(-spawnRangeY, spawnRangeY);
                Instantiate(flowerPrefabs[flowerIndex], worldPoint, flowerPrefabs[flowerIndex].transform.rotation);
            }
        }
    }
}
