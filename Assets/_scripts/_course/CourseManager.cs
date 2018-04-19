using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourseManager : MonoBehaviour
{
    public static CourseManager Instance;

    public Text currentLapText;
    public Text lastLapText;
    public Text bestLapText;
    public GameObject lapTick;
    public Transform checkpointParent;

    float _timer = 0;
    int _currentCheckpoint = -1;
    int _lastCheckpoint = -1;
    bool _timing;
    float _bestLap;


    private void Awake()
    {
        Instance = this;
        _bestLap = PlayerPrefs.GetFloat("BestLap", 500f);
        if (_bestLap < 500f)
            bestLapText.text = _bestLap.ToString("F2");
    }

    private void Update()
    {
        if (_timing)
        {
            _timer += Time.deltaTime;
            currentLapText.text = _timer.ToString("F2");
        }
    }

    public void HitCheckpoint(int number)
    {
        Debug.Log("hit checkpoint " + number);

        if (number == _lastCheckpoint)
        {
            Debug.Log("already at this checkpoint...");
            return;
        }

        if (number == 0 && !_timing) // starting new lap
            StartLap();
        else if (number == 0 && _currentCheckpoint == checkpointParent.childCount - 1) //  finished a lap
            FinishLap();
        else if (number == _currentCheckpoint + 1) // hit the next checkpoint
        {
            Debug.Log("moved to idx " + number);
            StartCoroutine("Tick");
            _currentCheckpoint = number;
        }
    }

    void StartLap()
    {
        Debug.Log("starting new lap");
        _currentCheckpoint = 0;
        _timer = 0;
        _timing = true;
    }

    void FinishLap()
    {
        // grab values
        float lapTime = _timer;

        Debug.Log("finished lap - " + lapTime.ToString("F2"));
        lastLapText.text = lapTime.ToString("F2");

        if (lapTime < _bestLap)
        {
            PlayerPrefs.SetFloat("BestLap", lapTime);
            bestLapText.text = lapTime.ToString("F2");
        }

        // start new lap
        StartLap();
    }

    IEnumerator Tick()
    {
        lapTick.SetActive(true);
        yield return new WaitForSeconds(1);
        lapTick.SetActive(false);
    }
}
