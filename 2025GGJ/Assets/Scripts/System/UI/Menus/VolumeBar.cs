using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    [SerializeField] Image bar2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBar();
    }

    private void SetBar()
    {
        bar2.fillAmount = AudioListener.volume;

    }
}
