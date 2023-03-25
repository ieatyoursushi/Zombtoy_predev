using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Pause : MonoBehaviour {
    public bool isPaused;
    public GameObject panel;
    PlayerHealth playerhealth;
    public GameObject firstPerson;
    // Use this for initialization
    private void Awake()
    {
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }
    private void Start()
    {
        panel.SetActive(false);
        panel.GetComponentInParent<Image>().enabled = false;
        firstPerson = GameObject.Find("FirstPerson");
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab) && !playerhealth.isDead)
        {
            pause();
            Cursor.lockState = CursorLockMode.None;
        }
	}
    public void pause()
    {
        panel.SetActive(true);
        panel.GetComponentInParent<Image>().enabled = true;
        isPaused = true;
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        isPaused = false;
        if (firstPerson != null)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        panel.GetComponentInParent<Image>().enabled = false;
    }
    public void exit()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
