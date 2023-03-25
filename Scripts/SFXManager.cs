using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SFXManager : MonoBehaviour {
    public Slider VolumeSlider;
    public AudioListener SFX;
    public static float volumeValue = 1f;
	// Use this for initialization
	void Start () {
        if (VolumeSlider != null)
        {
            VolumeSlider.value = volumeValue;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(VolumeSlider != null)
        {
            volumeValue = VolumeSlider.value;
        }

        AudioListener.volume = volumeValue;
        
	}
}
