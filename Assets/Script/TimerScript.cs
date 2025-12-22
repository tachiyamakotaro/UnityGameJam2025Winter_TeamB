using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;//シーン遷移に必要
public class TimerScript : MonoBehaviour
{

    private float timeLimit = 90.0f;
    public TextMeshProUGUI timerText;
    private bool isTimeUp = false;
    void Start()
    {

    }


    void Update()
    {
        //既に終了していたら何もしない
        if(isTimeUp)
        {
            return;
        }

        if(timeLimit > 0)
        {
            timeLimit -= Time.deltaTime;
            UpdateTimerText(timeLimit);
        }
        else
        {
            timeLimit = 0;
            UpdateTimerText(timeLimit);
            isTimeUp = true;
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
        SceneManager.LoadScene("Result");
    }
}
