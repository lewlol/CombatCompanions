using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager buttonManager;

    private void Awake()
    {
        buttonManager = this;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeObjectActive(GameObject gOBJ)
    {
        bool active = gOBJ.activeSelf;
        gOBJ.SetActive(!active);
    }
}
