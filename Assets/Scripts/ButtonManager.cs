using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}