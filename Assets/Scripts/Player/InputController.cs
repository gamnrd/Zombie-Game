using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Platform : short { PC, Mobile, Console, Web};

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public Vector2 move { get; private set; }
    public Vector2 mouseAim { get; private set; }
    [SerializeField]public Vector2 joystickAim { get; private set; }

    [SerializeField] public Platform platform;

    private void Awake()
    {
        Instance = this;
    }

    public Platform GetPlatform()
    {
        return platform;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnAimMouse(InputAction.CallbackContext context)
    {
        if (platform == Platform.PC || platform == Platform.Web)
        {
            mouseAim = context.ReadValue<Vector2>();
        }
    }

    public void OnAimJoystick(InputAction.CallbackContext context)
    {
        if (platform == Platform.Console || platform == Platform.Mobile)
        {
            joystickAim = context.ReadValue<Vector2>();
        }
    }
}
