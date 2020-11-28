using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    public static bool Active = false;

    private Vector2 _direction;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 5f;
    CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
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

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), Time.fixedDeltaTime * _turnSpeed * move.magnitude);
            var speed = _speed;

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
