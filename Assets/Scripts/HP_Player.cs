using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;

    public Image[] hearts; // หัวใจหลายดวง

    void Start()
    {
        currentHP = maxHP;
        UpdateHearts();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;

        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
                hearts[i].color = Color.red; // ยังมีเลือด
            else
                hearts[i].color = Color.gray; // หายไป
        }
    }
}