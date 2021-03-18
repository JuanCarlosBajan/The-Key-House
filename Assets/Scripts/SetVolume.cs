using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    static float bars = 1;
    void Start()
    {
        
        slider.value = Mathf.Abs(bars);

        
    }
    

    public void SetLevel (float sliderval)
    {
        mixer.SetFloat("MusicVol",Mathf.Log10(sliderval)*20);
        bars = sliderval;
    }
}
