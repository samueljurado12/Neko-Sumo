/*
 * Author: Samuel Jurado Quintana
 * Co-Authors: 
 * 
 * Date: 27/07/2019
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : Spawner
{

    [SerializeField] protected bool movesRight;

    public override void Spawn()
    {
        obstacle.GetComponent<Obstacle>().MovesRight = movesRight;
        Vector2 spawnPosition = new Vector2(this.transform.position.x, Random.Range(-size / 2, size / 2));
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
        base.ModifySpawnRate();
    }

    void OnDrawGizmos()
    {
            Gizmos.DrawCube(transform.position, new Vector3(1, size, 0));
    }
}
