using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;


public class GameplayController : MonoBehaviour
{
    private int level; // M�n ch?i hi?n t?i
    public TextMeshProUGUI levelText;
    private StaticBase SB;
    private Shop Sh;

    private void Start()
    {
        // L?y m�n ch?i hi?n t?i t? GameManager
        SB = GameManager.Instance.SB;
        Sh = GameManager.Instance.Sh;
        level = GameManager.Instance.currentLevel;
        UpdateLevel();
        // G?i h�m ?? kh?i t?o m�n ch?i d?a tr�n s? level
        InitializeLevel(level);
    }
    public void UpdateLevel()
    {
        levelText.text = "M�n " + level.ToString();
    }

    private void InitializeLevel(int level)
    {
        // Th?c hi?n kh?i t?o m�n ch?i d?a tr�n level
        // V� d?:
        Debug.Log("Initializing Level: " + level);

        // T�y thu?c v�o tr� ch?i c?a b?n, th�m logic ?? t?o qu�i, v?t ph?m, hay thi?t l?p kh�c theo level.
    }
}
