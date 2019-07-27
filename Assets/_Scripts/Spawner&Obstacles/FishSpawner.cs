/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: 
 * 
 * Date: 27/07/2019
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : Spawner
{
    public override void Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-size / 2, size / 2), this.transform.position.y);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
        base.ModifySpawnRate();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(size, 1, 0));
    }
}
