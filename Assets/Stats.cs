using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text timer;
    public Text deaths;

    private int death_counter;
    private float time;

    private bool StickComplete;
    private bool HeadComplete;
    private bool start_timer;

    private bool BackFromStick;
    private bool BackFromHead;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        StickComplete = false;
        HeadComplete = false;
        start_timer = false;
        death_counter = 0;
        time = 0f;
        BackFromHead = false;
        BackFromStick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Canvas>().worldCamera == null)
        {
            gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
        }
        if (BackFromHead && GameObject.Find("HeadTilt") != null)
        {
            BackFromHead = false;
            CompleteHead();
        }
        else if (BackFromStick && GameObject.Find("Controller") != null)
        {
            BackFromStick = false;
            CompleteStick();
        }

        if (!start_timer)
        {
            return;
        }
        time += Time.deltaTime;
        if ((int)(time % 60) < 10)
        {
            timer.text = "Time: " + (int)(time / 60) + ":0" + (int)(time % 60);
        }
        else
        {
            timer.text = "Time: " + (int)(time / 60) + ":" + (int)(time % 60);
        }
        
    }

    public void BackToLogin(string level)
    {
        if (level.Equals("Controller"))
        {
            BackFromStick = true;
        }
        else if (level.Equals("Head"))
        {
            BackFromHead = true;
        }
    }

    public void CompleteStick()
    {
        StickComplete = true;
        GameObject.Find("Controller").GetComponentInChildren<Text>().text = (int)(time / 60) + ":" + (int)(time % 60) + " and " + death_counter.ToString() + " deaths";
        GameObject.Find("Controller").GetComponent<Button>().interactable = false;
        time = 0f;
        death_counter = 0;
        start_timer = false;
        timer.text = "Timer: 0:00";
        deaths.text = "Deaths: 0";
        Destroy(gameObject);
    }

    public void CompleteHead()
    {
        HeadComplete = true;
        GameObject.Find("HeadTilt").GetComponentInChildren<Text>().text = (int)(time / 60) + ":" + (int)(time % 60) + " and " + death_counter.ToString() + " deaths";
        GameObject.Find("HeadTilt").GetComponent<Button>().interactable = false;
        time = 0f;
        death_counter = 0;
        start_timer = false;
        timer.text = "Timer: 0:00";
        deaths.text = "Deaths: 0";
        Destroy(gameObject);
    }

    public void StartTimer()
    {
        start_timer = true;
    }

    public void AddDeath()
    {
        death_counter++;
        deaths.text = "Deaths: " + death_counter.ToString();
    }
}
