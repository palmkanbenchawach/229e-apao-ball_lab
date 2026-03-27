using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHP = 3;
    public int currentHP;
    public Image[] hearts;
    public Color fullColor = Color.red;
    public Color emptyColor = Color.gray;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    [Header("Victory UI")]
    public GameObject victoryPanel;

    private bool isDeadOrWon = false;

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (victoryPanel != null)
            victoryPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ลด HP
    public void TakeDamage(int dmg)
    {
        if (isDeadOrWon) return;

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
            hearts[i].color = (i < currentHP) ? fullColor : emptyColor;
    }

    // Game Over
    void Die()
    {
        if (isDeadOrWon) return;
        isDeadOrWon = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Victory (ชนกล้วย)
    public void Win()
    {
        if (isDeadOrWon) return;
        isDeadOrWon = true;

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

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
        SceneManager.LoadScene("UI_Menu");
    }
}