using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    public int totalTime; // Default is 12 hours
    public int time;
    public float timeScale;

    [Header("Other Settings")]
    public int warningTime;

    private IEnumerator EndDay()
    {
        yield return new WaitForSeconds(warningTime);
        SceneManager.LoadScene(2);
    }

    private IEnumerator DayCycle()
    {
        yield return new WaitForSeconds(timeScale);
        time++;

        if (time > totalTime)
        {
            StartCoroutine("EndDay");
        }

        StartCoroutine("DayCycle");
    }

    void Start()
    {
        StartCoroutine("DayCycle");
    }

    void Update()
    {

    }
}
