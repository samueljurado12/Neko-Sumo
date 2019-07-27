/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: 
 * 
 * Date: 27/07/2019
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{

    [SerializeField] protected GameObject obstacle;
    [SerializeField] protected float size;

    private SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = GetComponentInParent<SpawnManager>();
    }

    public abstract void Spawn();

    protected void ModifySpawnRate()
    {
        spawnManager.spawnRate *= (1 - spawnManager.spawnIncrease);
    }
}
