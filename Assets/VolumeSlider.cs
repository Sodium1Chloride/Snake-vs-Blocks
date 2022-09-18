using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider Slider;
    public AudioSource Music;

    void Start()
    {
        Slider.value = Music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        Music.volume = Slider.value;
    }
    
}
