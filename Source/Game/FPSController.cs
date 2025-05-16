using System;
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
    public float Speed;
    public float JumpForce;

    private float _gravity = 2000;
    private float _yVelocity = 0;
    private float _mouseX;
    private float _mouseY;
    private int _jumpCount = 0;

    /// <inheritdoc/>
    public override void OnStart()
    {
        Screen.CursorLock = CursorLockMode.Locked;
        Screen.CursorVisible = false;
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        _mouseX += Input.GetAxis("Mouse X") * MouseSensitivity;
        _mouseY += Input.GetAxis("Mouse Y") * MouseSensitivity;

        _mouseY = Math.Clamp(_mouseY, -90, 90);

        Camera.EulerAngles = new Vector3(_mouseY, _mouseX, 0);
    }

    public override void OnFixedUpdate()
    {
        var moveInput = new Vector3
        {
            X = Input.GetAxis("Horizontal"),
            Z = Input.GetAxis("Vertical")
        };

        moveInput.Normalize();

        var lookRotation = new Vector3(0, Camera.LocalEulerAngles.Y, 0);
        var direction = Vector3.Transform(moveInput, Quaternion.Euler(lookRotation));
        var velocity = direction * Speed * Time.DeltaTime;
        
        CharacterController.Move(velocity);
    }
}
