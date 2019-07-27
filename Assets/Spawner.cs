using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float width, height;
    [SerializeField] private float spawnRate;
    [SerializeField] private float variance;
    [SerializeField] private float spawnIncrease;
    [SerializeField] private bool isVertical;
    [SerializeField] private bool movesRight;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            if (isVertical)
            {
                SpawnVertical(obstacle);
            }
            else
            {
                SpawnHorizontal(obstacle);
            }
            yield return new WaitForSecondsRealtime(spawnRate + Random.value * variance);
        }
    }

    void SpawnHorizontal(GameObject obstacle)
    {
        obstacle.GetComponent<Obstacle>().MovesRight = movesRight;
        Vector2 spawnPosition = new Vector2(Random.Range(-width / 2, width / 2), this.transform.position.y);
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
        spawnRate = spawnRate * (1 - spawnIncrease);
    }

    void SpawnVertical(GameObject obstacle)
    {
        Vector2 spawnPosition = new Vector2(this.transform.position.x, Random.Range(-height / 2, height / 2));
        Instantiate(obstacle, spawnPosition, Quaternion.identity);
        spawnRate = spawnRate * (1 - spawnIncrease);
    }

    void OnDrawGizmos()
    {
        if (isVertical)
        {
            Gizmos.DrawCube(transform.position, new Vector3(1, height, 0));
        }
        else
        {
            Gizmos.DrawCube(transform.position, new Vector3(width, 1, 0));
        }
        
    }
}
