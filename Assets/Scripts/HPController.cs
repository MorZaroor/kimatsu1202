using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public int maxHealth = 3;
    private static int currentHealth;
    public static Image[] heartImages;

    void Start()
    {
        currentHealth = maxHealth;
        heartImages = GetComponentsInChildren<Image>();
    }

    public void UpdateHealthBar()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
                heartImages[i].enabled = true;
            else
                heartImages[i].enabled = false;
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1;
        UpdateHealthBar();

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
