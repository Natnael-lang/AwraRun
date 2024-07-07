using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawnPoint = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                spawnTile(0);
            else
                spawnTile(Random.Range(1,tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z > zSpawnPoint - (tileLength * numberOfTiles))
            spawnTile(Random.Range(1, tilePrefabs.Length));
        if (activeTiles.Count > numberOfTiles + 1)
            deleteTile();
    }

    public void spawnTile(int tileIndex)
    {
        GameObject newTile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawnPoint, transform.rotation);
        activeTiles.Add(newTile);
        zSpawnPoint += tileLength;
    }
    private void deleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
