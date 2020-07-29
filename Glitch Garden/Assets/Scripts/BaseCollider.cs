using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCollider : MonoBehaviour
{
    HealthDisplay healthDisplay;
    private void Start()
    {
        healthDisplay = FindObjectOfType<HealthDisplay>();   
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Attacker>())
        {
            healthDisplay.ReduceHealth();
            Destroy(otherCollider.gameObject);
        }
    }
}
