using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public int totalTime; // Default is 12 hours
    public int time;
    public float timeScale;

    private IEnumerator DayCycle()
    {
        yield return new WaitForSeconds(timeScale);
        time++;

        if (time < totalTime)
        {
            // Do function for ending day
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
