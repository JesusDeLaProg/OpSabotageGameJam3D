using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{

    private Vector2 _direction;

    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerMovement();
    }
    
    private void UpdatePlayerMovement()
    {
        var move = _direction.y * Camera.main.transform.forward + _direction.x * Camera.main.transform.right;
        move.y = 0;

        if (move != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, move.normalized, _turnSpeed);

            var speed = _speed;

            transform.position = transform.position + move * speed * Time.fixedDeltaTime;
        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
   
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}
