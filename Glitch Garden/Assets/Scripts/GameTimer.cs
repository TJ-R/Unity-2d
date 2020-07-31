using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer In Seconds")]
    [SerializeField] float levelTime = 10;

    bool timeFinished;
    bool triggeredTimerFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredTimerFinished) return;

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timeFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timeFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
