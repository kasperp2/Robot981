using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private int _numberOfGravityChanges = 1;

    [SerializeField] private float _moveSpeed = 10f;

    [SerializeField] private float _jumpForce = 50f;

    [SerializeField] private float _feetRadius;
    [SerializeField] private float _feetDistance;
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 _moveDirection = Vector2.zero;
    public Vector2 gravityDirection = Vector2.zero;

    public int currentGravityChanges = 0;

    public Rigidbody2D rb;
    private Animator _animator;

    private SpriteRenderer _spriteRenderer;

    private float _velocityMagnitude;
    private Vector3 _lastPosition;

    private bool _isGrounded = false;

    public void ResetMovement()
    {
        rb.velocity = new Vector2(0, 0);
        InputManager.Instance.ResetGravity();
    }


    private void isGrounded()
    {
        if (Physics2D.CircleCast(transform.position, _feetRadius, -transform.up, _feetDistance, _groundLayer))
        {
            _isGrounded = true;

            if (currentGravityChanges != 0)
                currentGravityChanges = 0;
        }
        else
            _isGrounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position - transform.up * _feetDistance, _feetRadius);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);
    }

    private void Update()
    {
        HandleInputs();
        HandleRotation();
        HandleAnimation();
    }


    private void FixedUpdate()
    {
        isGrounded();
        HandleMovement();
        HandleJump();
        HandleGravity();
    }

    private void HandleInputs()
    {
        _moveDirection = InputManager.Instance.Move;

        gravityDirection = InputManager.Instance.GravityChange;

        if (currentGravityChanges >= _numberOfGravityChanges)
            InputManager.Instance.disableGravityChange = true;
        else
            InputManager.Instance.disableGravityChange = false;
    }

    private void HandleRotation()
    {
        var angle = 0;

        if (gravityDirection == Vector2.right)
            angle = 90;
        else if (gravityDirection == Vector2.up)
            angle = 180;
        else if (gravityDirection == Vector2.left)
            angle = 270;

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void HandleAnimation()
    {
        if(_isGrounded)
            if (_velocityMagnitude < 0.01f)
                _animator.Play("Idle");
            else
                _animator.Play("Walk");
        else
            _animator.Play("Air");
    }

    private void HandleMovement()
    {
        _velocityMagnitude = (transform.position - _lastPosition).magnitude;


        var constraindMove = _moveDirection;
        if (gravityDirection.x == 0)
            constraindMove.y = 0;
        else
            constraindMove.x = 0;


        rb.AddForce(constraindMove * _moveSpeed);

        _lastPosition = transform.position;
    }

    private void HandleJump()
    {
        if ((_moveDirection + gravityDirection).magnitude < 1 && _isGrounded)
        {
            rb.AddForce(gravityDirection * (-_jumpForce), ForceMode2D.Impulse);
        }
    }

    private void HandleGravity()
    {
        rb.AddForce(Physics.gravity.magnitude * gravityDirection * rb.mass);
    }

}
