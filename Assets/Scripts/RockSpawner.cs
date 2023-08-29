using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 1.5f;
    [SerializeField] float upperHeight = 0.45f;
    [SerializeField] float lowerHeight = -0.45f;
    [SerializeField] GameObject _rock;

    float timer;
    
    void Start()
    {
        SpawnRock();
    }

    void Update()
    {
        if(timer > maxTime)
        {
            SpawnRock();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnRock()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(lowerHeight, upperHeight));
        GameObject rock = Instantiate(_rock, spawnPos, Quaternion.identity);

        Destroy(rock, 10f);
    }

    
    
}
