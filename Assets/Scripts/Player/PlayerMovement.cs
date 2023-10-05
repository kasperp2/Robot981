using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _gravityDirection = Vector2.zero;

    private Rigidbody2D _rb;
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private float _velocityMagnitude;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        HandleInputs();
        HandleAnimation();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInputs()
    {
        _moveDirection = InputManager.Instance.Move;
        _gravityDirection = InputManager.Instance.GravityChange;
        Debug.Log(_gravityDirection);
    }


    private void HandleAnimation()
    {
        if (_velocityMagnitude < 0.01f)
        {
            _animator.Play("BlobPlayer_Blue_Idle");
        }
        else
        {
            _animator.Play("BlobPlayer_Blue_Walk");
        }
    }

    private void HandleMovement()
    {
        _velocityMagnitude = (transform.position - _lastPosition).magnitude;

        if (_gravityDirection.x != 0)


        _rb.AddForce(_moveDirection * _moveSpeed);



        _lastPosition = transform.position;
    }
}
