using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private RoadSpawner _roadSpawner;
    
    private OceanSpawner _oceanSpawner;

    private void OnEnable()
    {
        PlayerMovement.RoadTrigger += SpawnRoadTriggerEntered;
        PlayerMovement.OceanTrigger += SpawnOceanTriggerEntered;
    }

    private void OnDisable()
    {
        PlayerMovement.RoadTrigger -= SpawnRoadTriggerEntered;
        PlayerMovement.OceanTrigger -= SpawnOceanTriggerEntered;
    }

    // Start is called before the first frame update
    void Start()
    {
        _roadSpawner = GetComponent<RoadSpawner>();
        _oceanSpawner = GetComponent<OceanSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoadTriggerEntered()
    {
        _roadSpawner.MoveRoad();
    }
    
    public void SpawnOceanTriggerEntered()
    {
        _oceanSpawner.MoveOcean();
    }
}
