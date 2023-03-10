using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonCollect : MonoBehaviour
{
    public static event Action baloonCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            Debug.Log("COllided with player");
            baloonCollected?.Invoke();
            gameObject.SetActive(false);
        }   
    }

}
