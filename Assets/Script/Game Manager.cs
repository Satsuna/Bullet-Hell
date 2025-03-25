using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject loseUI;
    public GameObject winUI;
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && loseUI.activeSelf == false && winUI.activeSelf == false) {
            Pause();
        }
    }

    public void RetryClick() {
        SceneManager.LoadScene("Play");
    }

    public void MenuClick() {
        SceneManager.LoadScene("Start");
    }

    public void continueClick() {
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    void Pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }
}
