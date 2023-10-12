using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    [SerializeField] private int _sceneToLoadIndex;
    [SerializeField] private bool _isFinish = false;
    [SerializeField] private float _delay = 2f;

    private Animator _animator;

    private Coroutine _routine;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();

        _animator.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _animator.enabled = true;

            _routine = StartCoroutine(TriggerDelay());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

            StopCoroutine(_routine);
    }

    IEnumerator TriggerDelay()
    {
        yield return new WaitForSeconds(_delay);

        if (_isFinish)
        {
            UiManager.Instance.Finish();
            SceneHandler.Instance.ChangeScene(1);
        }
        else
        {
            SceneHandler.Instance.ChangeScene(_sceneToLoadIndex);
        }

        PlayerMovement.Instance.ResetMovement();
    }
}

