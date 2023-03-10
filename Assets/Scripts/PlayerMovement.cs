using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action RoadTrigger;
    public static event Action OceanTrigger;
    
    public float forwardSpeed;
    public float slowdownSpeed;
    public float horizontalSpeed;
    public float maxXValuePosition;

    public float floatingDuration;
    public float floatingHeight;
    private float originalYPos;
    private float floatingTime = 0f;

    private float _speed;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerHealth _health;
    
    private bool _isDead;
    
    
    public GameObject baloonRide;
    public GameObject playerCam;
    


    private void Awake()
    {
        _isDead = false;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_isDead)
        {
            if (Input.GetKey(KeyCode.S))
            {
                _speed = slowdownSpeed;
                _anim.speed = .75f;
            }
            else
            {
                _speed = forwardSpeed;
                _anim.speed = 1f;
            }
            
            _rb.MovePosition(transform.position + transform.forward * _speed * Time.fixedDeltaTime);

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector3 horizontalMovement = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;

            if (transform.position.x > -maxXValuePosition  && transform.position.x < maxXValuePosition)
            {
                _rb.MovePosition(_rb.position + horizontalMovement);
            } else if (transform.position.x > -maxXValuePosition)
            {
                _rb.MovePosition(_rb.position + transform.right * -1 * horizontalSpeed * Time.fixedDeltaTime);
            }
            else
            {
                _rb.MovePosition(_rb.position + transform.right * horizontalSpeed * Time.fixedDeltaTime);
            }
            

            if (_health.isPowerUp)
            {
                baloonRide.SetActive(true);
                playerCam.SetActive(false);
                originalYPos = transform.position.y;
                

                if (floatingTime == 0)
                {
                    transform.position = new Vector3(transform.position.x, floatingHeight,
                        transform.position.z);
                    _rb.useGravity = false;
                }
                
                floatingTime += Time.fixedDeltaTime;
                

                if (floatingTime >= floatingDuration)
                {
                    _rb.useGravity = true;
                    playerCam.SetActive(true);
                    baloonRide.SetActive(false);
                    _health.isPowerUp = false;
                    floatingTime = 0f;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadTrigger"))
        {
            RoadTrigger?.Invoke();
        }
        
        if (other.CompareTag("OceanTrigger"))
        {
            OceanTrigger?.Invoke();
        }
            
    }
}
