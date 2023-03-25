using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SelfDestruct : MonoBehaviour {
    public ParticleSystem explodeParticles;
    public GameObject explosionParticles;
    public EnemyHealth enemyHealth;
    bool exploded;
    public int BlaseDamage;
    public int MaxBlastDamage;
    public AudioSource BlastAudio;
    float timer;
    bool isIgniting;
    AudioSource block;
    public float ignite = 1.8f;
    // Use this for initialization
 
    void Start () {
        explodeParticles.Pause();
        explosionParticles.SetActive(false);
        enemyHealth = GetComponent<EnemyHealth>();
        timer = ignite;
        BlastAudio = GameObject.Find("BlastAudio").GetComponent<AudioSource>();
        block = GameObject.Find("block").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isIgniting)
        {
            timer -= Time.deltaTime;
        }
 
	}
    void Explode()
    {
        LayerMask mask = LayerMask.GetMask("Shootable");
        
        PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        Collider[] ExplodeRadius = Physics.OverlapSphere(transform.position, 3f);
        Collider[] DeadlyExplosionRadius = Physics.OverlapSphere(transform.position, 1f);
      
        foreach (Collider col in ExplodeRadius)
        {
            EnemyHealth eenemyHealth = col.GetComponent<EnemyHealth>();
            if(playerHealth != null && !enemyHealth.isDead && !enemyHealth.Rocket_Resistant)
            {
                explosionParticles.SetActive(true);
                playerHealth.TakeDamage(BlaseDamage);
                 
                explodeParticles.Play();
                BlastAudio.Play();
                enemyHealth.TakeDamage(10000, transform.position);
            }else if (eenemyHealth != null)
            {
                if(eenemyHealth.Rocket_Resistant)
                {
                    block.Play();
                }
            }
            if (eenemyHealth != null && !eenemyHealth.Rocket_Resistant)
            {
                eenemyHealth.TakeDamage(BlaseDamage / 4, transform.position);
            }
        }
        /*
        foreach(Collider col in DeadlyExplosionRadius)
        {
            if (playerHealth != null && !enemyHealth.isDead )
            {
                playerHealth.TakeDamage(MaxBlastDamage);
 
                 
                explodeParticles.Play();
                BlastAudio.Play();
            }
        }
        */
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            Explode();
        }
    }
 
}
