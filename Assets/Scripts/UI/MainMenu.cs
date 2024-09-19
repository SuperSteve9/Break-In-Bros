using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainScene()
    {
        // right now just load into scene Main
        SceneManager.LoadScene(1);
    }
}
