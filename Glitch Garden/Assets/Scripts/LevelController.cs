using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLable;
    [SerializeField] GameObject loseLable;
    [SerializeField] float timeBeforeLevelLoad = 5f;

    int attackerCount = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLable.SetActive(false);
        loseLable.SetActive(false);
    }

    public void AttackerSpawned()
    {
        attackerCount++;
    }

    public void AttackerKilled()
    {
        attackerCount--;
        if (levelTimerFinished && attackerCount <= 0)
        {
            Debug.Log("End Level Now");
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners) spawner.StopSpawning();
    }

    IEnumerator HandleWinCondition()
    {
        winLable.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeBeforeLevelLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLable.SetActive(true);
        Time.timeScale = 0;
    }
}
