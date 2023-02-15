using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force = 400;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _playerRadius = 1;

    private Rigidbody _rigidbody;
    private bool _isGrounded;

    private const float EPSILON = 0.001f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        CheckGround();
        Jump();
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetButton("Jump"))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce * Time.deltaTime);
            _isGrounded = false;
        }
    }

    private void CheckGround()
    {
        _isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            _playerRadius + EPSILON);
    }

    private void Move()
    {
        _rigidbody.AddForce(
            Vector3.forward * Input.GetAxis("Vertical") * _force * Time.deltaTime);
        
        _rigidbody.AddForce(
            Vector3.right * Input.GetAxis("Horizontal") * _force * Time.deltaTime);
    }
}
