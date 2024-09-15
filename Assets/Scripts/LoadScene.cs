using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // what else would i call it
    public void loadScene()
    {
        // right now just load into scene 1 = game = big balls
        SceneManager.LoadScene(1);
    }
}
