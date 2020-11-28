using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetection : MonoBehaviour
{
    [SerializeField] private float _interactionRange = 5f;
    private IInteractble _currentInteraction;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FindCloseInteraction();
    }

    void FindCloseInteraction()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.position + transform.forward * _interactionRange, Color.blue, 0.1f);

        if(Physics.Raycast(ray,out hit,_interactionRange))
        {
            IInteractble interactble = hit.collider.GetComponent<IInteractble>();

            if (interactble != null)
            {
                if (hit.distance <= interactble.interactionRange)
                {
                    if (interactble == _currentInteraction)
                    {
                        return;
                    }
                    else if(_currentInteraction != null)
                    {
                        _currentInteraction.OnExitRange();
                        _currentInteraction = interactble;
                        if (_currentInteraction.isAutoPickup)
                        {
                            _currentInteraction.OnInteract();
                        }
                        else
                        {
                             _currentInteraction.OnEnterRange();
                        }
                        return;
                    }
                    else
                    {
                        _currentInteraction = interactble;
                        if (_currentInteraction.isAutoPickup)
                        {
                            _currentInteraction.OnInteract();
                        }
                        else
                        {
                            _currentInteraction.OnEnterRange();
                        }
                        return;
                    }
                }
                else
                {
                    if(_currentInteraction != null)
                    {
                        _currentInteraction.OnExitRange();
                        _currentInteraction = null;
                        return;
                    }
                }
            }
            else
            {
                if (_currentInteraction != null)
                {
                    _currentInteraction.OnExitRange();
                    _currentInteraction = null;
                    return;
                }
            }
        }else
        {
            if (_currentInteraction != null)
            {
                _currentInteraction.OnExitRange();
                _currentInteraction = null;
                return;
            }
        }
    }
    private void Interact()
    {
        if (_currentInteraction != null)
        {
            _currentInteraction.OnInteract();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Interact();
        }
    }
}
