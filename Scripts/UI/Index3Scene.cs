using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Index3Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void settingsScene()
    {
        SceneManager.LoadScene(3);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void leaderboardScene()
    {
        SceneManager.LoadScene(4);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
