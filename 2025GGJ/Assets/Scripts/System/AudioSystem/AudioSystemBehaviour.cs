using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystemBehaviour : MonoBehaviour
{
    public static AudioSystemBehaviour Instance;

    [SerializeField] private AudioSource musicSource, effectSource;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public void PlayerSound(AudioClip clip, float volume)
    {
        effectSource.PlayOneShot(clip, volume);
    }

    public void ChangeMasterVolume(float volumeFloat)
    {
        AudioListener.volume = volumeFloat;
    }

    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
}
