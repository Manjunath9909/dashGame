using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleHandler : MonoBehaviour
{
    //imports for obstacles
    public obstacle obstaclePrefab;
    public Transform bottomObstacleSpawn;
    public Transform topObstacleSpawn;
    void Awake()
    {
        //setupObstaclePool();
        Instantiate(obstaclePrefab, bottomObstacleSpawn);
        Instantiate(obstaclePrefab, topObstacleSpawn);
    }
    public void setupObstaclePool()
    {
        myPool.setUpMyPool(obstaclePrefab, 10, "obstacle");
    }
}
