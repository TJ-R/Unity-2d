using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetStarCost() { return starCost; }
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount); 
    }
}
