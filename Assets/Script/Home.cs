using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Time.timeScale = 1;
    }
    public void StartClick() {
        SceneManager.LoadScene("Play");
    }

    public void QuitClick() {
        Application.Quit();
    }
}
