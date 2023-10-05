using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private int _sceneToLoadIndex;


    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }


    private void StartGame()
    {
        SceneManager.LoadScene(_sceneToLoadIndex);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
