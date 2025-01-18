using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] List<AudioClip> moveSoundList;
    int soundCount;
    private void Start()
    {
        if (moveSoundList == null)
        {
            moveSoundList = new();
        }
        else
        {
            soundCount = moveSoundList.Count;
        }
    }

    public IEnumerator PlayMoveSound()
    {
        MoveSound(soundCount);
        yield return null;
    }

    void MoveSound(int soundCount)
    {
        AudioSystemBehaviour.Instance.PlayerSound(moveSoundList[Random.Range(0, soundCount-1)],1);
    }
}
