using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

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
            transform.Rotate(new Vector3(0, horizontalInput, 0));
        }
    }
}
