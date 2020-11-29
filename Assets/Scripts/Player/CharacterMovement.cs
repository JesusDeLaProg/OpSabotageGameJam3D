using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    public static bool Active = false;
    public static Action _levelEnded;
    public static Action _respawnBadGuy;
    public static Action _victory;
    private Vector2 _direction;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 5f;
    CharacterController _characterController;
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _levelEnded += OnLevelEnded;
        _respawnBadGuy += OnRespawnBadGuy;
        _victory += OnVictory;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Active) return;
        UpdatePlayerMovement();
        ApplyGravity();
    }

    private void UpdatePlayerMovement()
    {
        Vector3 _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = _forward.normalized;
        var move = _direction.y * _forward + _direction.x * Camera.main.transform.right;

        if (!_characterController.isGrounded)
        {
            _animator.SetBool("isFalling", true);
            return;
        }
        else
        {
            _animator.SetBool("isFalling", false);
        }

        if (move != Vector3.zero)
        {
            
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.fixedDeltaTime * _turnSpeed * move.magnitude);
            var speed = _speed;
            _animator.SetFloat("Speed", 0.2f);
            _animator.speed = _direction.magnitude * 2f;


            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position + move.normalized * 1f, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                _characterController.Move(move * speed * Time.fixedDeltaTime);
            }
        }
        else
        {
            //Reset Velocity?
            _animator.SetFloat("Speed", 0);
            _animator.speed = 1;

        }

    }
    private void ApplyGravity()
    {
        //Apply gravity 
        _characterController.Move(Physics.gravity * Time.fixedDeltaTime);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void PlayerDeath()
    {
        _animator.SetBool("isDead", true);
    }

    private void OnRespawnBadGuy()
    {
        _animator.SetTrigger("Respawn");
    }

    private void OnVictory()
    {
        _animator.SetTrigger("Victory");
    }

    private void OnLevelEnded()
    {
        PlayerDeath();
        _animator.speed = 1;
    }
}
