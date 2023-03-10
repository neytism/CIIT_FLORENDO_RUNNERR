using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerHealth _health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health.IsFullHealth())
        {
            _anim.SetBool("IsCrawling", false);
        }
        else
        {
            _anim.SetBool("IsCrawling", true);
        }

        if (_health.isPowerUp)
        {
            _anim.SetBool("IsFloating", true);
        }
        else
        {
            _anim.SetBool("IsFloating", false);
        }
    }
    
}
