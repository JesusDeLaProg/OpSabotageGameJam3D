using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    private Vector2 _direction;

    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 2f;
    CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        //_rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMovement();
    }
    
    private void UpdatePlayerMovement()
    {
        Vector3 _forward = Camera.main.transform.forward;
        _forward.y = 0;
        var move = _direction.y * _forward + _direction.x * Camera.main.transform.right;
       // move.y = 0;

        if (move != Vector3.zero)
        {
            //transform.forward = Vector3.Lerp(transform.forward, move.normalized, _turnSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * _turnSpeed);
            var speed = _speed;

            //Apply gravity 
            move.y += Physics.gravity.y * Time.fixedDeltaTime * 5f;
            //transform.position = transform.position + move * speed * Time.fixedDeltaTime;
            _characterController.Move(move * speed * Time.fixedDeltaTime);

        }
        else
        {
            //_rigidbody.angularVelocity = Vector3.zero;
            
        }
   
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}
