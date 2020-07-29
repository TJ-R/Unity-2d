using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int health = 5;

    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
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
            StartCoroutine(WaitAndLoadGameOver());
        }
    }

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<LevelLoader>().LoadGameOver();
    }
}
