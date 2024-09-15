using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public double totalTime = 9;
    public TMP_Text timeText;
    public double timeScale = 1;
    public PauseMenuManager pauseMenuscript;

    void Update()
    {
        if (!pauseMenuscript.isInMenu)
        {
            switch (totalTime)
            {
                case var expression when totalTime >= 9 && totalTime <= 10:
                    timeText.text = "9:" + FormatToMinutes(totalTime) + " PM";
                    break;
                case var expression when totalTime > 10 && totalTime <= 11:
                    timeText.text = "10:" + FormatToMinutes(totalTime) + " PM";
                    break;
                case var expression when totalTime > 11 && totalTime <= 12:
                    timeText.text = "11:" + FormatToMinutes(totalTime) + " PM";
                    break;
                case var expression when totalTime > 12 && totalTime <= 13:
                    timeText.text = "12:" + FormatToMinutes(totalTime) + " AM";
                    break;
                case var expression when totalTime > 13 && totalTime <= 14:
                    timeText.text = "1:" + FormatToMinutes(totalTime) + " AM";
                    break;
                case var expression when totalTime > 14 && totalTime <= 15:
                    timeText.text = "2:" + FormatToMinutes(totalTime) + " AM";
                    break;
                case var expression when totalTime > 15 && totalTime <= 16:
                    timeText.text = "3:" + FormatToMinutes(totalTime) + " AM";
                    break;
                case var expression when totalTime > 16 && totalTime <= 17:
                    timeText.text = "4:" + FormatToMinutes(totalTime) + " AM";
                    break;
                case var expression when totalTime > 17 && totalTime <= 18:
                    timeText.text = "5:" + FormatToMinutes(totalTime) + " AM";
                    break;
                default:
                    SceneManager.LoadScene(2);
                    break;

            }
            totalTime += 1 * Time.deltaTime * timeScale;
        }
    }

    string FormatToMinutes(double time)
    {
        int hour = (int)time;
        int minute = (int)((time - hour) * 60);
        return minute.ToString("D2");
    }
}
