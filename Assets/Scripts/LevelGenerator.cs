using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject coinPrefab;
    public int totalCoins = 15;
    public float planeSize = 10f;

    private GameObject currentPlane;
    private List<GameObject> coins = new List<GameObject>();

    private void Start()
    {
        GenerateInitialPlane();
        GenerateCoins();
    }

    private void GenerateInitialPlane()
    {
        currentPlane = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
    }

    private void GenerateCoins()
    {
        for (int i = 0; i < totalCoins; i++)
        {
            float randomX = Random.Range(-planeSize / 2f, planeSize / 2f);
            float randomZ = Random.Range(-planeSize / 2f, planeSize / 2f);

            Vector3 coinPosition = currentPlane.transform.position + new Vector3(randomX, 0.5f, randomZ);
            GameObject coin = Instantiate(coinPrefab, coinPosition, Quaternion.identity);
            coins.Add(coin);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 newPlanePosition = currentPlane.transform.position;

            if (other.transform.position.x > currentPlane.transform.position.x + planeSize / 2f)
            {
                newPlanePosition.x += planeSize;
            }
            else if (other.transform.position.x < currentPlane.transform.position.x - planeSize / 2f)
            {
                newPlanePosition.x -= planeSize;
            }
            else if (other.transform.position.z > currentPlane.transform.position.z + planeSize / 2f)
            {
                newPlanePosition.z += planeSize;
            }
            else if (other.transform.position.z < currentPlane.transform.position.z - planeSize / 2f)
            {
                newPlanePosition.z -= planeSize;
            }

            currentPlane = Instantiate(planePrefab, newPlanePosition, Quaternion.identity);
            GenerateCoins();
        }
    }
}
