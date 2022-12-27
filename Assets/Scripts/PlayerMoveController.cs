using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0)
        {
            Vector3 newPosition = transform.position + transform.forward * (verticalInput * (Time.deltaTime * moveSpeed));
            transform.position = newPosition;
            
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (horizontalInput != 0)
        {
            transform.Rotate(new Vector3(0, horizontalInput * rotationSpeed, 0));
            if (horizontalInput < 0)
            {
                _animator.SetBool("rotLeft", true);
                _animator.SetBool("rotRight", false);
            }

            if (horizontalInput > 0)
            {
                _animator.SetBool("rotRight", true);
                _animator.SetBool("rotLeft", false);
            }
        }
        else
        {
            _animator.SetBool("rotRight", false);
            _animator.SetBool("rotLeft", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _animator.SetTrigger("Jump");
    }

    private void LateUpdate()
    {
        _animator.ResetTrigger("Jump");
    }
}
