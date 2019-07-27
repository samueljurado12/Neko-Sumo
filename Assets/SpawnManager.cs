/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: 
 * 
 * Date: 27/07/2019
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] public float spawnRate;
    [SerializeField] private float variance;
    public float spawnIncrease;

    private Spawner[] spawners;

    private void Awake()
    {
        spawners = GetComponentsInChildren<Spawner>();
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            Spawner spawner = spawners[Random.Range(0, spawners.Length)];
            spawner.Spawn();
            yield return new WaitForSecondsRealtime(spawnRate + Random.value * variance);
        }
    }
}
