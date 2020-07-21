using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    // cached references
    TextMeshProUGUI heathText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        heathText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        heathText.text = player.GetHealth().ToString();
    }
}
