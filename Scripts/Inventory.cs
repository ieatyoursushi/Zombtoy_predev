using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public GameObject MachineGunPrefab;
    public GameObject ShotgunPrefab;

    public GameObject Shotgun;
    public GameObject MachineGun;
    public GameObject RocketLaunche;
    public GameObject CryoPistol;

    public AudioSource ShotgunAU;
    public AudioSource MachineGunAU;
    public AudioSource RocketLauncherAU;
    public AudioSource CryoPistolAU;

    public reloadCheck machineGunCheck;
    public reloadCheck shotgunCheck;
    public reloadCheck[] barrels;
    public reloadCheck pistolCheck;
    public reloadCheck rocketLauncherCheck;

    public PlayerHealth playerHealth;
    // not used
    bool played = false; //machinegun
    bool played2 = false; //shotgun
    bool played3 = false; //rocketlauncher
    bool played4 = false; // cryo pistol
    public Text GunText;
	// Use this for initialization
	void Start () {
        RocketLaunche.SetActive(false);
        CryoPistol.SetActive(false);
        MachineGun.SetActive(true);
        Shotgun.SetActive(false);
    }
 
	public void Guns()
    {
        if (!playerHealth.isDead)
        {
            if (Input.GetKeyDown(Keybinds.slot1Bind) && !playerHealth.isDead)
            {
                RocketLaunche.SetActive(false);
                CryoPistol.SetActive(false);
                MachineGun.SetActive(true);
                Shotgun.SetActive(false);
                GunText.text = "Machine Gun";
                GunText.fontSize = 69;
                if (played == false)
                {
                    MachineGunAU.Play();
                    played2 = false;
                    played = true;
                    played3 = false;
                    played4 = false;
                    machineGunCheck.reload = false;
                }
            }

            if (Input.GetKeyDown(Keybinds.slot2Bind) && !playerHealth.isDead)
            {
 
                RocketLaunche.SetActive(false);
                CryoPistol.SetActive(false);
                MachineGun.SetActive(false);
                Shotgun.SetActive(true);
                GunText.text = "Shotgun";
                GunText.fontSize = 69;
                if (played2 == false)
                {
                    ShotgunAU.Play();
                    played2 = true;
                    played = false;
                    played3 = false;
                    played4 = false;
                    shotgunCheck.reload = false;
                    foreach(reloadCheck reload in barrels)
                    {
                        reload.reload = false;
                    }
                }

            }
            if (Input.GetKeyDown(Keybinds.slot3Bind) && !playerHealth.isDead)
            {
                GunText.text = "Rocket Launcher";
                GunText.fontSize = 55;
                Shotgun.SetActive(false);
                MachineGun.SetActive(false);
                RocketLaunche.SetActive(true);
                CryoPistol.SetActive(false);
                if (played3 == false)
                {
                    RocketLauncherAU.Play();
                    played = false;
                    played2 = false;
                    played3 = true;
                    played4 = false;
                    rocketLauncherCheck.reload = false;
                }
            }
            if (Input.GetKeyDown(Keybinds.slot4Bind) && !playerHealth.isDead)
            {
                GunText.text = "Cryo Pistol";
                RocketLaunche.SetActive(false);
                CryoPistol.SetActive(true);
                MachineGun.SetActive(false);
                Shotgun.SetActive(false);
                MachineGun.SetActive(false);
                if (played4 == false)
                {
                    CryoPistolAU.Play();
                    played = false;
                    played2 = false;
                    played3 = false;
                    played4 = true;
                    pistolCheck.reload = false;
 
                }
 
            }
        }
       
    }
	// Update is called once per frame
	void Update () {
        Guns();	
	}
}
