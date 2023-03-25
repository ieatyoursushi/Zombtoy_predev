using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TornadoLaunch : MonoBehaviour {
    public GameObject Tornado;
    public float coolDown;
    float timer;
    public GameObject Slider;
    PlayerHealth playerHealth;
    // Use this for initialization
    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>(); 
    }
    void Start () {
        Slider.GetComponent<Slider>().maxValue = coolDown;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (!playerHealth.isDead)
        {
            Slider.GetComponent<Slider>().value = timer;
        }
		if(Input.GetButtonDown("Fire2") && timer > coolDown && Time.timeScale != 0 && !playerHealth.isDead)
        {
            Shoot();
        }
        if(timer >= coolDown)
        {
            
        } else
        {
             
        }
	}
    public void Shoot()
    {
        timer = 0f;
        Instantiate(Tornado, transform.position, transform.rotation);
    
    }
}
 
 
