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
            //TODO: реализовать
        }

        return "--:--";
    }

    private int GetSeconds()
    {
        switch (mode)
        {
            case TimerMode.SinceStartOfTheGame: return (int) Time.time;
            case TimerMode.SinceStartOfTheTimer: return (int) (Time.time - _startTime);
            default: return 0;
        }
    }

    private string TimeToStrV1(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        string minStr = minutes.ToString().PadLeft(2, '0');
        string secStr = seconds.ToString().PadLeft(2, '0');
        return $"{minStr}:{secStr}";
    }

    private string TimeToStrV2(int totalSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
        return time.ToString("mm\\:ss");
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
