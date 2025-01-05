using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton
    public StaticBase SB;
    public Shop Sh;

    public int currentLevel = 1; // Màn ch?i hi?n t?i

    private void Awake()
    {
        // ??m b?o ch? có m?t GameManager t?n t?i
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không phá h?y khi chuy?n scene
        }
        else
        {
            Destroy(gameObject); // H?y n?u ?ã có GameManager khác
        }
    }
    private void Start()
    {
        // Kh?i t?o ch? s? c? b?n và ti?n
        SB = new StaticBase();
        Sh = new Shop();
    }


    // Chuy?n sang màn ch?i ti?p theo
    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadSceneAsync(1);
    }
    public void GameOver()
    {
        SceneManager.LoadSceneAsync(3);
    }

    // Chuy?n ??n scene Shop
    public void GoToShop()
    {
        SceneManager.LoadSceneAsync(2);
    }

    // Reset v? màn ??u tiên (n?u c?n)
    public void ResetGame()
    {
        currentLevel = 1;
        SB = new StaticBase();
        Sh = new Shop();
        SceneManager.LoadSceneAsync(1);
    }
    public void BackGame()
    {
        currentLevel = 1;
        SB = new StaticBase();
        Sh = new Shop();
        SceneManager.LoadSceneAsync(0);
    }
}
