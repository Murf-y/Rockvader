using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManagerMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource themeAudio = GetComponent<AudioSource>();
        themeAudio.volume = PlayerPrefs.GetFloat("sliderValue");
    }

}
