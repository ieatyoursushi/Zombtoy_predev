using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour {
    public PlayerHealth playerHealth;
    public int AmmoMagazineMultiplyer;
    public AudioSource ammoPickup;
    public ItemManager itemManager;
    public Ammo machineGunAmmo;
    public Ammo shotgunAmmo;
    public Ammo[] barrels;
    public Ammo pistolAmmo;
    public Ammo rocketLauncherAmmo;
    public Transform gameObjectSpawnPoint;
    // Use this for initialization
    void Start () {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        itemManager = GameObject.Find("ItemManager (1)").GetComponent<ItemManager>();
        ammoPickup = GameObject.Find("AmmoSound").GetComponent<AudioSource>();
	}
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(machineGunAmmo != null)
            {
                machineGunAmmo.Capacity += machineGunAmmo.maxAmmo;
 
            }
            if (shotgunAmmo != null)
            {
                shotgunAmmo.Capacity += shotgunAmmo.maxAmmo;
                foreach(Ammo Ammo in barrels)
                {
                    Ammo.Capacity += Ammo.maxAmmo;
                }
            }
            if (pistolAmmo != null)
            {
                pistolAmmo.Capacity += pistolAmmo.maxAmmo;
            }
            if (rocketLauncherAmmo != null)
            {
                rocketLauncherAmmo.Capacity += rocketLauncherAmmo.maxAmmo * 2;
            }

            ammoPickup.Play();
 
            ScoreManager.score++;
            this.itemManager.ItemAmount--;
            StartCoroutine(DestroyAndAddSpawnPoint());
            gameObject.GetComponent<Collider>().enabled = false;
             
        }
    }
    IEnumerator DestroyAndAddSpawnPoint()
    {
        yield return new WaitForSeconds(0f);
        for(int i = 0; i < itemManager.spawnPoints.Length; i++)
        {
            if(itemManager.spawnPoints[i] == gameObjectSpawnPoint)
            {
                itemManager.SpawnPointsList.Add(itemManager.spawnPoints[i]);
            }
        }
        Destroy(gameObject);
    }
    private void Update()
    {
 
        transform.Rotate(0f,100f * Time.deltaTime, 0f, Space.Self);
 
        
    }

}
