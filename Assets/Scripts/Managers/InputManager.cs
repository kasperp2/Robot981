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

    public bool disableGravityChange = false;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);

        ResetGravity();
    }

    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void OnGravityChange(InputValue value)
    {
        if(disableGravityChange == false)
        {
            _gravityChange = value.Get<Vector2>();
            PlayerMovement.Instance.currentGravityChanges++;
        }
    }

    public void OnRestartLevel()
    {
        var spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

        PlayerMovement.Instance.ResetMovement();
        PlayerMovement.Instance.rb.transform.position = spawnPoint.position;
    }

    public void OnRestartGame()
    {
        UiManager.Instance.ResetTimer();
        SceneHandler.Instance.ChangeScene(2);
    }

    public void ResetGravity()
    {
        _gravityChange = new Vector2(0, -1);
    }
}
