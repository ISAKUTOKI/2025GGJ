using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        if (slider == null)
            return;
        else
        {
            AudioSystemBehaviour.Instance.ChangeMasterVolume(slider.value);
            slider.onValueChanged.AddListener(val => AudioSystemBehaviour.Instance.ChangeMasterVolume(val));
        }
    }

}
