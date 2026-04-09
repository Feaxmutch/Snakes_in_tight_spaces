using UnityEngine;
using ViewModel;
using UnityEngine.InputSystem;

public class InputBroadcaster : MonoBehaviour, IUserInput
{
    [SerializeField] private LayerMask _layerMask;

    private InputActions _inputActions;

    public Vector2 MousePosition { get; private set; }

    public bool IsMouseHold { get; private set; }

    private void Awake()
    {
        _inputActions = new();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.GameplayMap.Move.performed += OnMove;
        _inputActions.GameplayMap.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        _inputActions.GameplayMap.Move.performed -= OnMove;
        _inputActions.GameplayMap.Move.canceled -= OnMove;
        _inputActions.Disable();
    }

    private void Update()
    {
        HandleMouseInput();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void HandleMouseInput()
    {
        bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100, _layerMask.value);

        float x = hit.point.x;
        float y = hit.point.z;

        if (isHit == false)
        {
            x = -1;
            y = -1;
        }
        
        MousePosition = new Vector2(x, y);

        if (Input.GetMouseButtonDown(0))
        {
            IsMouseHold = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsMouseHold = false;
        }
    }
}