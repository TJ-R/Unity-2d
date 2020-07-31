using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 5;
    float health;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        health = baseHealth - PlayerPrefsController.GetDifficulty();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = "HP: " + health.ToString();
    }

    public void ReduceHealth()
    {
        if (health > 0)
        {
            health -= 1;
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
