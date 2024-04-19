using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;
    private bool interactPressed = false;
    private bool continuePressed = false;
    private bool pausePressed = false;

    private static InputManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static InputManager GetInstance()
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    public void PauseButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pausePressed = true;
        }
        else if (context.canceled)
        {
            pausePressed = false;
        }
    }

    public void ContinueButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            continuePressed = true;
        }
        else if (context.canceled)
        {
            continuePressed = false;
        }
    }

    public Vector2 GetMoveDirection()
    {
        return moveDirection;
    }

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetPausePressed()
    {
        bool result = pausePressed;
        pausePressed = false;
        return result;
    }

    public bool GetContinuePressed()
    {
        bool result = continuePressed;
        continuePressed = false;
        return result;
    }

    public void RegisterContinuePressed()
    {
        continuePressed = true;
    }

}
