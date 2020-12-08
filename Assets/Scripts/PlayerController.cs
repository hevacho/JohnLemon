using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 movement = Vector3.zero;

    private Animator _animator;

    private Rigidbody _rigidbody;

    private AudioSource _audioSource;

    [SerializeField]
    private float turnSpeed;
    
    private Quaternion _rotation = Quaternion.identity;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal, 0, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        _animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
        

    }


    void FixedUpdate()
    {
       
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement,
            turnSpeed * Time.fixedDeltaTime, 0f);

        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        //animacion que tiene moviento //Espacio = e0 + v*t
        _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }
}
