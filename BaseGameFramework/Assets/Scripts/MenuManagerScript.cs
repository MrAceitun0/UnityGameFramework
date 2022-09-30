using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManagerScript : MonoBehaviour
{

    public void loadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}