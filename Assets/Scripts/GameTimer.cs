using System;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TimerMode mode = TimerMode.SinceStartOfTheGame;
    public TimeRenderMode renderMode = TimeRenderMode.MinSec;

    private TMP_Text timerText;

    private float _startTime;

    void Start()
    {
        timerText = transform.GetComponentInChildren<TMP_Text>();
        _startTime = Time.time;
    }

    public void ResetTimer()
    {
        _startTime = Time.time;
    }

    void Update()
    {
        //sec = 100
        //"01:40"
        int totalSeconds = GetSeconds();
        timerText.text = SecondsToString(totalSeconds);
    }

    private string SecondsToString(int totalSeconds)
    {
        switch (renderMode)
        {
            case TimeRenderMode.MinSec: return SecondsToMinSec(totalSeconds);
            case TimeRenderMode.HourMinSec: return SecondsToHourMinSec(totalSeconds);
        }
        return "--:--";
    }

    private int GetSeconds()
    {
        switch (mode)
        {
            case TimerMode.SinceStartOfTheGame: return (int)Time.time;
            case TimerMode.SinceStartOfTheTimer: return (int)(Time.time - _startTime);
            default: return 0;
        }
    }

    private string SecondsToMinSec(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        string minStr = minutes.ToString().PadLeft(2, '0');
        string secStr = seconds.ToString().PadLeft(2, '0');
        return $"{minStr}:{secStr}";
    }

    private string SecondsToHourMinSec(int totalSeconds)
    {
        int hours = totalSeconds / 3600;
        int minutes = totalSeconds % 3600 / 60;
        int seconds = totalSeconds % 60;
        string hourStr = hours.ToString().PadLeft(2, '0');
        string minStr = minutes.ToString().PadLeft(2, '0');
        string secStr = seconds.ToString().PadLeft(2, '0');
        return $"{hourStr}:{minStr}:{secStr}";
    }

    public enum TimerMode
    {
        SinceStartOfTheGame,
        SinceStartOfTheTimer,
    }

    public enum TimeRenderMode
    {
        MinSec,     //00:00
        HourMinSec, //00:00:00
    }

}
