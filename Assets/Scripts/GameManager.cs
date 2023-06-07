using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject coinPrefab;
    public GameObject portal;

    public int totalCoins = 15;

    private int collectedCoins = 0;
    private bool gameComplete = false;

    private void Start()
    {
        SpawnCoins();
    }

    public void CollectCoin()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        portal.SetActive(true);
        gameComplete = true;
    }

    public bool IsGameComplete()
    {
        return gameComplete;
    }

    private void SpawnCoins()
    {
        
        MeshRenderer groundRenderer = player.GetComponent<MeshRenderer>();
        Vector3 groundSize = groundRenderer.bounds.size;

        
        float spacing = 1.5f;
        float startX = -groundSize.x / 2f + spacing;
        float startY = -groundSize.y / 2f + spacing;

        for (int i = 0; i < totalCoins; i++)
        {
            float x = startX + (i % 5) * spacing;
            float y = startY + (i / 5) * spacing;

            
            Vector3 coinPosition = new Vector3(x, y, 0f);
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
