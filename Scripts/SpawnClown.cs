using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClown : MonoBehaviour {
    public EnemyHealth enemyHealth;
    public Transform ClownSpawnPoint;
    public GameObject MiniClown;
    public bool spawned;
    public AudioSource SpawnSound;
    public zombieCount ZombieCount;
    private int clownsSpawned = 1;
    private float spawnProbabillity;
    public AnimationCurve animationCurve;
 
	// Use this for initialization
	void Start () {
         if(GameObject.Find("PoofSound") != null)
        {
            SpawnSound = GameObject.Find("PoofSound").GetComponent<AudioSource>();
            ZombieCount = GameObject.Find("ZombieCount").GetComponent<zombieCount>();
        }
        spawnProbabillity = Random.Range(0, 100);
        if(spawnProbabillity <= 15)
        {
            clownsSpawned++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(enemyHealth.isDead)
        {
            Invoke("Spawn", 1f);
        }
         
    }
    void Spawn()
    {
        if (enemyHealth.isDead && !spawned)
        {
            for (int i = 0; i < clownsSpawned; i++)
            {
                GameObject miniClown = Instantiate(MiniClown, ClownSpawnPoint) as GameObject;
                miniClown.transform.parent = null;
                ZombieCount.entityCount += 1;
            }
            spawned = true;
            SpawnSound.Play();
        }
    }
}
