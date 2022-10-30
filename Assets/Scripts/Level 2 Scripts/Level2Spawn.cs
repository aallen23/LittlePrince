using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spawn : MonoBehaviour
{

    [SerializeField] Timer timer;

    [SerializeField] GameObject[] spacePrefabs;
    [SerializeField] GameObject planet;
    [SerializeField] Vector2 spawnPos;
    [SerializeField] GameObject spawnHolder;

    [SerializeField] int index;
    [SerializeField] int length;

    [SerializeField] float size;

    [SerializeField] float Xspawn, Yspawn;
    [SerializeField] float spawnInterval;

    [SerializeField] bool spawn = false;
    [SerializeField] bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        
        Xspawn = 12.0f;
        Yspawn = 5.0f;

        length = spacePrefabs.Length;
 
        StartCoroutine(SpawnIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.timer == false && end == false)
        {
            end = true;
            StopSpawning();
            SpawnPlanet();
        }
    }

    IEnumerator SpawnIn()
    {
        spawn = true;
        while (spawn)
        {
            spawnInterval = Random.Range(0.0f, 2.0f);
            spawnPos = new Vector2(Xspawn, (Random.Range(-Yspawn, Yspawn)));
            index = Random.Range(0, length);
            size = Random.Range(0.5f, 1.5f);

            GameObject spaceObj = Instantiate(spacePrefabs[index], spawnPos, Quaternion.Euler(0, 0, Random.Range(0, 360)), spawnHolder.transform);
            spaceObj.transform.localScale = new Vector2(size, size);

            yield return new WaitForSeconds(spawnInterval);
        }
    }


    public void StopSpawning()
    {
        spawn = false;
    }

    
    public void SpawnPlanet()
    {
        Instantiate(planet, new Vector2(25, 0), planet.transform.rotation);
    }

}
