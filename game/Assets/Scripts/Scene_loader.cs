using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_loader : MonoBehaviour
{
    public void load_s(string name_s)
    {
        SceneManager.LoadScene(name_s);
    }
    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void exit_app()
    {
        Application.Quit();
    }
}
