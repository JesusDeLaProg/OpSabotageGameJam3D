using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public static bool Active = false;

    private Vector2 _direction;

    [SerializeField] private float _speed = 4;
    [SerializeField] private float _turnSpeed = 2f;
    CharacterController _characterController;
    [SerializeField] BoxCollider DeadCollider;

    public GameObject GooParticles;
    public GameObject SleepyParticles;
    public Transform[] PathPoints;
    public bool Loop = false;
    public bool PathReverse = false;

    private List<Vector3> pathPositions;
    private int currentTargetIndex = 0;
    private Vector3 currentTarget;
    public bool IsActiveSingle;

    public Animator Anim;

    public void OnDrawGizmos()
    {
        if (PathPoints == null || PathPoints.Length == 0) return;
        Gizmos.color = Color.green;
        Vector3 position;
        if(pathPositions == null || pathPositions.Count == 0)
        {
            position = transform.position;
            foreach (var point in PathPoints)
            {
                if (point == null) return;
                Gizmos.DrawLine(position, point.position);
                position = point.position;
            }
            if (Loop) Gizmos.DrawLine(position, transform.position);
        }
        else
        {
            position = pathPositions[0];
            foreach(var pos in pathPositions)
            {
                Gizmos.DrawLine(position, pos);
                position = pos;
            }
            if (Loop) Gizmos.DrawLine(position, pathPositions[0]);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, currentTarget);
        }
        
    }



    public void Activate()
    {
        Anim.SetTrigger("WakeUp");
        var awaiter = Task.Delay(3000).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            _characterController = GetComponent<CharacterController>();
            pathPositions = (new Vector3[] { transform.position }).Concat(PathPoints.Select(t => t.position)).ToList();
            currentTargetIndex = 1;
            currentTarget = pathPositions[1];
            DeadCollider.enabled = false;
            IsActiveSingle = true;
            SleepyParticles.SetActive(false);
            GooParticles.SetActive(true);
        });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Active || !IsActiveSingle) return;

        Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 target = new Vector2(currentTarget.x, currentTarget.z);
        Vector2 vectorToTarget = target - currentPos;
        if (vectorToTarget.magnitude > 0.1)
        {
            _direction = vectorToTarget.normalized;
        }
        else
        {
            MoveToNextTarget();
        }
        UpdatePlayerMovement();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!Active || !IsActiveSingle) return;

        if (hit.gameObject.CompareTag("Player")) GameState.CurrentLevel.EndLevel(false);
    }

    private void UpdatePlayerMovement()
    {
        if (!Active || !IsActiveSingle) return;

        Vector3 move = new Vector3(_direction.x, 0, _direction.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move, Vector3.up), Time.deltaTime * _turnSpeed);
        var speed = _speed;

        if (!_characterController.isGrounded) move = Vector3.zero; // Do not walk if falling

        //Apply gravity 
        move.y += Physics.gravity.y * Time.fixedDeltaTime * 5f;

        _characterController.Move(move * speed * Time.fixedDeltaTime);

    }

    private void MoveToNextTarget()
    {
        if (!Active || !IsActiveSingle) return;

        if (Loop)
        {
            currentTargetIndex = (currentTargetIndex + 1) % pathPositions.Count;
        }
        else
        {
            if((PathReverse && currentTargetIndex == 0) || (!PathReverse && currentTargetIndex == pathPositions.Count - 1))
            {
                PathReverse = !PathReverse;
            }
            currentTargetIndex += PathReverse ? -1 : 1;
        }
        currentTarget = pathPositions[currentTargetIndex];
    }
}
