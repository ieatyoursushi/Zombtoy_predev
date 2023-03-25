using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Pistol : MonoBehaviour {
    public GameObject IceBullet;
    public float cooldown;
    float timer;
    public AudioSource Shoot;
    public Ammo ammoScript;
    public PlayerHealth playerHealth;
    // Use this for initialization

 
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldown <= timer && timer != 0)
        {
            if (ammoScript.ammo > 0 && ammoScript.reloadTimer == 0 && !ammoScript.ReloadCheck.reload && !playerHealth.isDead)
            {
                ammoScript.ammo--;
                Instantiate(IceBullet, transform.position, transform.rotation);
                Shoot.Play();
                timer = 0f;
            }
        }
    }
}
