using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{

    private float timeLimit = 90.0f;
    public TextMeshProUGUI timerText;
    void Start()
    {

    }


    void Update()
    {
        if(timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            UpdateTimerText(timeLimit);
        }
        else
        {
            timeLimit = 0;
            UpdateTimerText(timeLimit);
            TimeUp();
        }
    }


    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void TimeUp()
    {
        Debug.Log("TimeUp!");
    }
}
