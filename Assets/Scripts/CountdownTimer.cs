using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ?? qu?n l� chuy?n scene
using TMPro; // N?u d�ng TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Th?i gian ??m ng??c (60 gi�y)
    public TMP_Text timerText; // Text ?? hi?n th? th?i gian (ho?c d�ng Text n?u kh�ng d�ng TMP)

    private float currentTime;

    private void Start()
    {
        // G�n gi� tr? th?i gian b?t ??u
        currentTime = countdownTime;
    }

    private void Update()
    {
        // Gi?m th?i gian m?i frame
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // ??m b?o th?i gian kh�ng b? �m
            if (currentTime < 0)
                currentTime = 0;

            // C?p nh?t UI hi?n th? th?i gian
            UpdateTimerText();
        }
        else
        {
            // Chuy?n sang scene Shop
            GameManager.Instance.GoToShop();
        }
    }

    private void UpdateTimerText()
    {
        // ??nh d?ng th?i gian theo ph�t:gi�y
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{seconds:00}";
    }
}
