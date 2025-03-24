using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Escape)) {
                Time.timeScale = 1;
            }
        }
    }

    public void RetryClick() {
        SceneManager.LoadScene("Play");
    }

    public void MenuClick() {
        SceneManager.LoadScene("Start");
    }
}
