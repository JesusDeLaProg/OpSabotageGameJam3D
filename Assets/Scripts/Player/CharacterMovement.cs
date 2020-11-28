using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    private Vector2 _direction;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 5f;
    CharacterController _characterController;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePlayerMovement();
        ApplyGravity();
    }
    
    private void UpdatePlayerMovement()
    {
        Vector3 _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = _forward.normalized;
        var move = _direction.y * _forward + _direction.x * Camera.main.transform.right;

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.fixedDeltaTime * _turnSpeed * move.magnitude);
            var speed = _speed;
            _animator.SetFloat("Speed", 0.2f);
            float playBackSpeed = 0.25f *1;
            Debug.Log("Playback Speed:" + _direction.magnitude);// move.magnitude / (speed * Time.fixedDeltaTime));
            _animator.speed = _direction.magnitude * 2f;
            Mathf.Clamp(playBackSpeed, 0.5f, 1.5f);
            _characterController.Move(move * speed * Time.fixedDeltaTime);

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
}
