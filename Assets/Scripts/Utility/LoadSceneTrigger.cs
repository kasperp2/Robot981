using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] private int _sceneToLoadIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SceneHandler.Instance.ChangeScene(_sceneToLoadIndex);
    }
}
