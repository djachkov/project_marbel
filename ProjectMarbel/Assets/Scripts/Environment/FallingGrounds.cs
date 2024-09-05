using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGrounds : MonoBehaviour
{
    [SerializeField] GameObject[] roadTiles;   // To collect all the tiles with tag "Road"   
    [SerializeField] private GameObject hole;   // Replaces the destroyed tile with a hole
    private List<int> fallenTiles = new List<int>();   // Collects the array indices of already destroyed tiles
    [SerializeField] private bool isUniqueIndex = true;   // Ensure that a NEW tile is destroyed each time interval 
    private float timeInterval = 15.0f;   // A tile is destroyed each timeInterval (controls number of destroyed tiles and the frequency
    private float lastDestroyTime;    // stores the last time a tile was destroyed


    // Start is called before the first frame update
    void Start()
    {
        roadTiles = GameObject.FindGameObjectsWithTag("Road");   // Road tiles only are allowed to fall
        lastDestroyTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastDestroyTime >= timeInterval)
        {
            destroyRandomTile();
            lastDestroyTime = Time.time;
        }
    }

    void destroyRandomTile()
    {
        while (isUniqueIndex == true)
        {
            int tileIndex = UnityEngine.Random.Range(0, roadTiles.Length);
            if (!fallenTiles.Contains(tileIndex))
            {
                var tile = roadTiles[tileIndex];
                Instantiate(hole, tile.transform.position, tile.transform.rotation);
                fallenTiles.Add(tileIndex);
                Destroy(tile);
                isUniqueIndex = false;
            }
        }
        isUniqueIndex = true;
    }
}