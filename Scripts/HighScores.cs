using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HighScores : MonoBehaviour {
    const string privateCode = "28pLBGexQkO4JU3gIMeCFA4TBtyDlkmUKO8ENc_Ae-0A";
    const string publicCode = "623ccd6b8f40bc123c38c9dc";
    const string webURL = "http://dreamlo.com/lb/";
    // Use this for initialization
    public Highscore[] highscoreList;
    public List<GameObject> Placeholder = new List<GameObject>();
 
    private void Awake()
    {
        
    }
 
    public void addNewHighScore(string user, int score)
    {
        StartCoroutine(UploadHighScore(user, score));
        StartCoroutine(downloadScoresFromDatabase());
    }
    IEnumerator UploadHighScore(string user, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(user) + "/" + score);
        yield return www;
        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful");
        } else
        {
            print("Not Successful");
        }
    }
    IEnumerator downloadScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            print(www.text);
        }
        else
        {
            print("error downloading");
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(800, 450, 122, 112), "Leaderboard");
        if(GUI.Button(new Rect(800, 500, 50, 20), "button"))
        {

        }
    }

    public struct Highscore
    {
        public string username;
        public int score;
        public Highscore (string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }
}
