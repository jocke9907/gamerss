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
        // Update the current time based on the countDown flag.
        // If countDown is true, subtract Time.deltaTime from currentTime.
        // If countDown is false, add Time.deltaTime to currentTime.
        // Time.deltaTime represents the time elapsed since the last frame.

        if (hasLimit && (countDown &&  currentTime < timerLimit) || (!countDown && currentTime >= timerLimit))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;

            // If there is a timer limit and the current time is within the limit:
            // - Set currentTime to the timerLimit.
            // - Call the SetTimerText() method to update the timer text.
            // - Set the color of timerText to red.
            // - Disable the script by setting enabled to false, stopping the timer.
        }

        SetTimerText();

    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[formats]) : currentTime.ToString();
        // Update the text displayed for the timer.
        // If hasFormat is true, format the currentTime using the format specified in timeFormats[formats].
        // Otherwise, convert currentTime to a string without any specific format.
    }

}


public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HunderethsDecimal
}
