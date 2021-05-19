using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public float zSpawn = 0.0f;
    public float titleLength = 30.0f;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTrasform;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(1, tilePrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrasform.position.z - 35 > zSpawn - (numberOfTiles * titleLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += titleLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
