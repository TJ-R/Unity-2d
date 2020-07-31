using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 4f;

    public static float GetMasterVolume() { return PlayerPrefs.GetFloat("master volume"); }
    public static float GetDifficulty() { return PlayerPrefs.GetFloat("difficulty"); }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat("master volume", volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat("difficulty", difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range.");
        }
    }
}
