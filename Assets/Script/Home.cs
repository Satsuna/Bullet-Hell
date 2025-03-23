using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update()
    {
        
    }

    public void StartClick() {
        SceneManager.LoadScene("Play");
    }
}
