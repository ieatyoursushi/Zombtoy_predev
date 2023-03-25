using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour {
    public GameObject image;
    public static bool muted = false;
 
	// Use this for initialization
	void Start () {
        image.SetActive(false);
	}
	public void mute()
    {
        if (!muted)
        {
            image.SetActive(true);
            muted = true;
            MusicManager.MusicOn = true;
        } else if (muted)
        {
            image.SetActive(false);
            muted = false;
            MusicManager.MusicOn = false;
        }
        Debug.Log(muted);

    }
	// Update is called once per frame
	void Update () {
		
	}
}
