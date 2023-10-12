using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _levelText;

    public GameObject hud;

    private float _timer = 0f;
    private bool _isRunning = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this);

        UpdateLevelText(1);
    }

    void Update()
    {
        if (_isRunning)
        {
            _timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        _isRunning = true;
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public void ResetTimer()
    {
        _timer = 0f;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_timer / 60);
        int seconds = Mathf.FloorToInt(_timer % 60);
        int milliseconds = Mathf.FloorToInt(_timer * 10 % 10);

        string timerString = string.Format("{0:00}:{1:00}.{2:0}", minutes, seconds, milliseconds);

        _timerText.text = timerString;
    }

    public void UpdateLevelText(int level)
    {
        _levelText.text = string.Format("Level {0} / 6", level);
    }

    public void Finish()
    {
        StopTimer();
        PlayerPrefs.SetFloat("currentTime", _timer);

        var currentBestTime = PlayerPrefs.GetFloat("bestTime", 0.0f);

        if (currentBestTime == 0.0f || currentBestTime > _timer)
        {
            PlayerPrefs.SetFloat("bestTime", _timer);
        }
    }
}
