using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer In Seconds")]
    [SerializeField] float levelTime = 10;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timeFinished) Debug.Log("Time is up!!!");
    }
}
