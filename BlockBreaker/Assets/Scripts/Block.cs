using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakAudio;

    // cached reference
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        level.CountBreakbleBlocks();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
        gameStatus.addToScore();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakAudio, Camera.main.transform.position, .3f);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
