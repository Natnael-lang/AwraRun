using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{

    public GameObject[] tilePrefabs;  // declaring list for the different tiles used
    public float zSpawn = 0; // to track the position along the z axis where the next tile will be spawned
    public float TILELENGTH = 30; // declaring length of the tile
    public int NUMBEROFTILES = 3; // declaring the number of tiles active at a time
    public Transform playerTransform; // declaring the player transform 
    private List<GameObject> activeTiles = new List<GameObject>(); // declaring a list to save the active files

    // Start is called before the first frame update
    void Start()
    {
        // making the first three tiles appear randomly
        for (int i = 0; i < NUMBEROFTILES; i++) 
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(1, tilePrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if the player advanced beyond the current set of tiles
        if (playerTransform.position.z - 15 > zSpawn - (NUMBEROFTILES * TILELENGTH)) 
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length)); // generate random tiles from prefabs
            DeleteTile(); // to delete the first inserted tile
        }
    }
    // a method for spawning of tiles in the game
    public void SpawnTile(int tileIndex)
    {
        // creating the a game object based on the prefab given by the tileIndex
        GameObject gameObject = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(gameObject); // adding the instantiated tile to the active tile list
        zSpawn += TILELENGTH; // increasing the zSpawn by the the tile length
    }

    private void DeleteTile() // a method for deleting tiles 
    {
        Destroy(activeTiles[0]); // destroys the first inserted lane
        activeTiles.RemoveAt(0); // removes the first inserted lane
    }
}
