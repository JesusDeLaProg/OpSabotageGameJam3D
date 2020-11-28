﻿using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    private Vector2 _direction;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 2f;
    CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePlayerMovement();
    }
    
    private void UpdatePlayerMovement()
    {
        Vector3 _forward = Camera.main.transform.forward;
        _forward.y = 0;
        var move = _direction.y * _forward + _direction.x * Camera.main.transform.right;

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * _turnSpeed);
            var speed = _speed;

            //Apply gravity 
            move.y += Physics.gravity.y * Time.fixedDeltaTime * 5f;

            _characterController.Move(move * speed * Time.fixedDeltaTime);

        }
        else
        {
            //Reset Velocity?
            
        }
   
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}
