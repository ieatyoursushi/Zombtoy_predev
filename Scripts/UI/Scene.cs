using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
	}
    public void GameScene()
    {
        SceneManager.LoadScene(6);
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void isometric()
    {
        SceneManager.LoadScene(1);
    }
    public void firstPerson()
    {
        SceneManager.LoadScene(5);
    }
    void Update () {
		
	}
}
