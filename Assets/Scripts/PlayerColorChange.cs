using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{

    public List<Renderer> renderer;


    private void OnEnable()
    {
        EventsManager.onRedPortal += ChangeToRed;
        EventsManager.onGreenPortal += ChangeToGreen;
    }
    
    
    private void OnDisable()
    {
        EventsManager.onRedPortal -= ChangeToRed;
        EventsManager.onGreenPortal -= ChangeToGreen;
    }

    public void ChangeToRed()
    {
        foreach (var mesh in renderer)
        {
            mesh.material.color = Color.red;
        }
    }
    
    public void ChangeToGreen()
    {
        foreach (var mesh in renderer)
        {
            mesh.material.color = Color.green;
        }
    }
}
