using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject Player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerMovement pm;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDuration;


    void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0) // right
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition= Player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) // left
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(-20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0) // up
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0) // down
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) // right up
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) // right down
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) // left up
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) // left down
        {
            if (Physics2D.OverlapCircle(Player.transform.position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = Player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }
        }

    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if(optimizerCooldown <= 0f) 
        {
            optimizerCooldown = optimizerCooldownDuration;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
