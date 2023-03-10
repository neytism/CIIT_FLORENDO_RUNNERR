using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;

    public List<Transform> positions;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeObstacle()
    {
        foreach (var VARIABLE in positions)
        {
            GameObject obstacle = obstacleSpawner.obstacles[Random.Range(0, obstacleSpawner.obstacles.Count)];
            Instantiate(obstacle,VARIABLE);
        }
    }
    
}
