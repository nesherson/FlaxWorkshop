using FlaxEngine;

namespace Game;

/// <summary>
/// FPSController Script.
/// </summary>
public class FPSController : Script
{
    public CharacterController CharacterController;
    public Camera Camera;
    public float MouseSensitivity;

    private float mouseX;
    private float mouseY;

    /// <inheritdoc/>
    public override void OnStart()
    {
        Screen.CursorLock = CursorLockMode.Locked;
        Screen.CursorVisible = false;  
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * MouseSensitivity;

        Camera.EulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
