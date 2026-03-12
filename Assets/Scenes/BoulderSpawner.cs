using UnityEngine;
using System.Collections;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject boulderPrefab;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(4f, 5f);
            yield return new WaitForSeconds(waitTime);

            SpawnBoulder();
        }
    }

    void SpawnBoulder()
    {
       float radius = 15f;

// Pick random direction around a circle
Vector2 randomCircle = Random.insideUnitCircle.normalized * radius;

Vector3 spawnPosition = new Vector3(
    randomCircle.x,
    5f,
    randomCircle.y
);

        GameObject boulder = Instantiate(boulderPrefab, spawnPosition, Quaternion.identity);

// Random size between small and big
float randomSize = Random.Range(0.5f, 2.5f);
boulder.transform.localScale = Vector3.one * randomSize;

// Calculate direction toward center
Vector3 direction = (Vector3.zero - spawnPosition).normalized;

// Bigger rocks move slower, smaller move faster
float forceAmount = 1200f / randomSize;

// Push the boulder
boulder.GetComponent<Rigidbody>().AddForce(direction * 400f);
    }
}