using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawnProf : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public PolygonCollider2D polygonCollider;
    public GameObject spawnerObject;

    private Timer _timer;
    private float startDelay = 1;
    public float spawnInterval = 1.7f;



    void Start()
    {
        _timer = GameObject.Find("Timer").GetComponent<Timer>();
        InvokeRepeating("SpawnFlower", startDelay, spawnInterval);
    }

    private Vector2 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector2(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale)

        );
    }


    public void SpawnFlower()
    {
        int flowerIndex = Random.Range(0, flowerPrefabs.Length);
        if (_timer.timer && spawnerObject.transform.childCount < 10)
        {

            Vector2 randomPoint2D = RandomPointInBounds(polygonCollider.bounds, 1f);
            Vector2 rndPointInside = polygonCollider.ClosestPoint(new Vector2(randomPoint2D.x, randomPoint2D.y));
            if (rndPointInside.x == randomPoint2D.x && rndPointInside.y == randomPoint2D.y)
            {
                Instantiate(flowerPrefabs[flowerIndex], randomPoint2D, flowerPrefabs[flowerIndex].transform.rotation,
                    spawnerObject.gameObject.transform);
            }

        }
    }

}
