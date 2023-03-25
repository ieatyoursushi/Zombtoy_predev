using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour {
    public Text highscoreText;
    public Text MonstersKilled;
    public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        highscoreText.text = ScoreManager.highScore.ToString();
        MonstersKilled.text = ScoreManager.MonsterKills.ToString();
        score.text = ScoreManager.score.ToString();
	}
}
