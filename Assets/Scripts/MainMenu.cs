using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void NextGame()
    {
        GameManager.Instance.NextLevel();
    }
    public void ResetGamee()
    {
        GameManager.Instance.ResetGame();
    }
    public void BackMenu()
    {
        GameManager.Instance.BackGame();
    }
}
