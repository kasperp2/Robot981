using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private Vector2 _move;
    public Vector2 Move => _move;

    private Vector2 _gravityChange;
    public Vector2 GravityChange => _gravityChange;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);
    }

    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void OnGravityChange(InputValue value)
    {
        _gravityChange = value.Get<Vector2>();
    }
}
