using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public Transform CenterObj;

    private Vector3 _cameraOffset;
    private float _cameraOffsetRayon;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RotationsSpeed = 5.0f;

    Vector2 _direction;

    public float x;
    public float y;

    bool active = true;
    public Animator Anim;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        _cameraOffset = transform.position - CenterObj.position;
        var dist = Vector3.Distance(_cameraOffset, CenterObj.position);
        _cameraOffsetRayon = dist;
        var vec = Vector3.forward;//CenterObj.transform.forward;
        var quat = Quaternion.Euler(-y, x, 0);
        vec = quat * vec;
        var newPos = CenterObj.transform.position + vec * _cameraOffsetRayon;
        transform.position = newPos;
        transform.LookAt(CenterObj.transform);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (active)
        {
            x += _direction.x * RotationsSpeed;
            y += _direction.y * RotationsSpeed;
            y = Mathf.Clamp(y, 0, 85f);
            var vec = Vector3.forward;//CenterObj.transform.forward;
            var quat = Quaternion.Euler(-y, x, 0);
            vec = quat * vec;
            var newPos = CenterObj.transform.position + vec * _cameraOffsetRayon;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
            transform.LookAt(CenterObj.transform);
        }
        else
        {
            if (GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize > 2)
            {
                GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize -= 0.1f;
            }
            var pos = (Quaternion.Euler(-10f, 0f, 0f) * CenterObj.forward * 2) + CenterObj.transform.position;
            transform.position = Vector3.Slerp(transform.position, pos, SmoothFactor * 0.5f);
            transform.LookAt(CenterObj.transform);
        }
    }

    public void CenterOnPlayer()
    {
        active = false;
        Anim.SetTrigger("FadeOut");
    }
}
