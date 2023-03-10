using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OceanSpawner : MonoBehaviour
{
    public List<GameObject> ocean;

    [SerializeField] private float offset = 21f;

    // Start is called before the first frame update
    void Start()
    {
        if (ocean != null && ocean.Count > 0)
        {
            ocean = ocean.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveOcean()
    {
        GameObject moveOcean = ocean[0];
        ocean.Remove(moveOcean);
        float newZ = ocean[ocean.Count - 1].transform.position.z + offset;
        moveOcean.transform.position = new Vector3(0, 0, newZ);
        ocean.Add(moveOcean);
    }
}
