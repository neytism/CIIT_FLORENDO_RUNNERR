using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    
    
    public bool isRed;

    public bool isGreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRed)
            {
                EventsManager.Instance.RedPortal();
            }
            else if (isGreen)
            {
                EventsManager.Instance.GreenPortal();
            }
            
        }
    }
}
