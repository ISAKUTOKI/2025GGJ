using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] List<AudioClip> moveClipList;
    int soundCount;

    private void Start()
    {
        if (moveClipList == null)
        {
            moveClipList = new List<AudioClip>();
            soundCount = 0;
        }
        else
        {
            soundCount = moveClipList.Count;
        }
    }

    public IEnumerator PlayMoveSound()
    {
        MoveSound();
        yield return null;
    }

    void MoveSound()
    {
        if (soundCount > 0)
        {
            AudioSystemBehaviour.Instance.PlayerSound(moveClipList[Random.Range(0, soundCount)], 1);
        }
        else
        {
            Debug.LogWarning("No move sounds available.");
        }
    }
}