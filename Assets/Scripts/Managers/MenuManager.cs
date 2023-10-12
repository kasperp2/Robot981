using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _resetTimeButton;
    [SerializeField] private TextMeshProUGUI _bestTimeText;
    [SerializeField] private TextMeshProUGUI _currentTimeText;
    [SerializeField] private int _sceneToLoadIndex;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _resetTimeButton.onClick.AddListener(ResetTime);

        UiManager.Instance.hud.SetActive(false);

        var bestTime = PlayerPrefs.GetFloat("bestTime", 0.0f);

        if(bestTime != 0.0f)
        {
            _bestTimeText.text = FormatTime(bestTime);
        }

        var currentTime = PlayerPrefs.GetFloat("currentTime", 0.0f);

        if (currentTime != 0.0f)
        {
            _currentTimeText.text = FormatTime(currentTime);
        }
    }

    private void StartGame()
    {
        UiManager.Instance.hud.SetActive(true);
        UiManager.Instance.ResetTimer();
        UiManager.Instance.StartTimer();

        SceneHandler.Instance.ChangeScene(2);
    }

    private void ResetTime()
    {
        PlayerPrefs.SetFloat("bestTime", 0.0f);
        _bestTimeText.text = "No Best Time";
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt(time * 10 % 10);

        return string.Format("{0:00}:{1:00}.{2:0}", minutes, seconds, milliseconds);
    }
}