using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    #region Instance

    private static EventsManager _instance;
    public static  EventsManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion
    
    public delegate void PortalEvent();

    public static event PortalEvent onRedPortal = delegate {  };
    public static event PortalEvent onGreenPortal = delegate {  };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RedPortal()
    {
        onRedPortal?.Invoke();
    }

    public void GreenPortal()
    {
        onGreenPortal?.Invoke();
    }
}
