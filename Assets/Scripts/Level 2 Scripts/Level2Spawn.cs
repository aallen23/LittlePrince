using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Spawn : MonoBehaviour
{

    [SerializeField] GameObject[] spacePrefabs;
    [SerializeField] Vector2 spawnPos;

    [SerializeField] int index;
    [SerializeField] int length;

    [SerializeField] float Xspawn, Yspawn;
    [SerializeField] float spawnInterval;

    [SerializeField] bool spawn = false;

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
        
    }

    IEnumerator SpawnIn()
    {
        spawn = true;
        while (spawn)
        {
            spawnInterval = Random.Range(0.0f, 2.0f);
            spawnPos = new Vector2(Xspawn, (Random.Range(-Yspawn, Yspawn)));
            index = Random.Range(0, length);
            Instantiate(spacePrefabs[index], spawnPos, spacePrefabs[index].transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    public void StopSpawning()
    {
        spawn = false;
    }

}
