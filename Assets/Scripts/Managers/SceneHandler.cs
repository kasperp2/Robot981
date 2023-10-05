using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);

    }

    public void ChangeScene(int index)
    {
        StartCoroutine(ChangeSceneRoutine(index));
    }

    private IEnumerator ChangeSceneRoutine(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
