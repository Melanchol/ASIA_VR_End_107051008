using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene("VRsence");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
