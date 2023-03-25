using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour {
    public static bool MusicOn = true;
    public Slider VolumeSlider;
    public AudioSource backgroundMusic;
    public static float volumeValue = 0.354f;
	// Use this for initialization
	void Start () {
		if(MuteButton.muted == true)
        {
            backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            backgroundMusic.Play();
 
        }  
	}
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update () {
        if(VolumeSlider != null)
        {
            volumeValue = VolumeSlider.value;
        }
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volumeValue;
        }
    }
}
