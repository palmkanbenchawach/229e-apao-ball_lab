using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHP = 3;
    public int currentHP;
    public Image[] hearts;
    public Color fullColor = Color.red;   // สีหัวใจเต็ม
    public Color emptyColor = Color.gray; // สีหัวใจหมด

    [Header("Game Over UI")]
    public GameObject gameOverPanel; // Panel Game Over

    private bool isDead = false;

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); // เริ่มต้นปิด Panel

        // ซ่อนเมาส์ตอนเล่น
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        currentHP -= dmg;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = (i < currentHP) ? fullColor : emptyColor;
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true); // เปิด Panel Game Over

        // ปลดล็อกเมาส์และให้เห็น
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ปุ่ม UI
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("UI_Menu"); // ใส่ชื่อซีนเมนูของคุณ
    }
}