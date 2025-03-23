using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick() {
        SceneManager.LoadScene("Play");
    }
}
