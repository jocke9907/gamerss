using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeTimer : MonoBehaviour
{
    [Header("Component")]   
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Setting")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats formats;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    //--------------Sam---------------------------------------

    bool yellowActivated = false;
    bool redActivated = false;

    //---------------------------------------------------------

    private void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timeFormats.Add(TimerFormats.HunderethsDecimal, "0.00");

    }


    private void Update()
    {

//-----------------------SAM--------------------------------------
        if (currentTime <= 30 && yellowActivated == false)
        {
            yellowActivated = true;
            timerText.color = Color.yellow;
        }
        if (currentTime <= 10 && redActivated == false)
        {
            redActivated = true;
            timerText.color = Color.red;
        }

//----------------------------------------------------------------
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        

        if (hasLimit && (countDown &&  currentTime < timerLimit) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false; 
        }

        SetTimerText();

    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[formats]) : currentTime.ToString(); 
         
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HunderethsDecimal
}
