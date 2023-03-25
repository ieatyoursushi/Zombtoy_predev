using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyShooting : MonoBehaviour {
    public GameObject Projectile;
    public Transform shootPoint;
    public float cooldown;
    PlayerHealth playerHealth;
    public range Range;
    public NavMeshAgent navMeshAgent;
    public GameObject Player;
    EnemyHealth enemyHealth;
    public AudioSource FireballSound;
    public AudioSource FireballSound2;
    public AudioSource[] spawnSounds;
    public AudioSource[] Dialogues;
    int spawnSoundProbability;
    int DialogueProbabillity;
    Light lights;
    public ParticleSystem explosionShield;
    // Use this for initialization
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        lights = GetComponent<Light>();
    }
    void Start () {
        InvokeRepeating("shoot", 1f, cooldown);
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        Player = GameObject.Find("Player");
        spawnSoundProbability = Random.Range(0, 100);
        if(spawnSoundProbability > 50)
        {
            spawnSounds[0].Play();
        }
        else if(spawnSoundProbability <= 50)
        {
            spawnSounds[1].Play();
        }
        explosionShield.Stop();
        lights.range = 0;
        lights.intensity = 0;
	}
 
    // Update is called once per frame
    void Update () {
        if(!Range.inRange)
        {
            navMeshAgent.speed = 4f;
        }
        else if(Range.inRange)
        {
            Vector3 AimLine = Player.transform.position - shootPoint.position;
            AimLine.y = 0f;
            Debug.DrawLine(Player.transform.position, shootPoint.position);
            shootPoint.rotation = Quaternion.LookRotation(AimLine);
        }

        if(!explosionShield.isPlaying)
        {
            lights.range = Mathf.Lerp(0, 10, .2f * Time.deltaTime);
            lights.intensity = Mathf.Lerp(0, 2, 0.1f * Time.deltaTime);
            
        } else
        {
            lights.range = Mathf.Lerp(10, 0, .2f * Time.deltaTime);
            lights.intensity = Mathf.Lerp(2, 0, 0.2f * Time.deltaTime);
        }
	}
    void shoot()
    {
         
        if (!playerHealth.isDead && Range.inRange && !enemyHealth.isDead)
        {
            Instantiate(Projectile, shootPoint.position, shootPoint.rotation);
            navMeshAgent.speed = 2f;
            FireballSound.Play();
            FireballSound2.Play();
            Dialogue();
            explosionShield.Play();
        } else
        {
            explosionShield.Stop();
        }
    }
    void Dialogue()
    {
        DialogueProbabillity = Random.Range(0, 100);
        if (DialogueProbabillity <= 6)
        {
            Dialogues[0].Play();
        }
        else if (DialogueProbabillity > 6 && DialogueProbabillity <= 12)
        {
            Dialogues[1].Play();
        }
        else if (DialogueProbabillity > 12 && DialogueProbabillity <= 18)
        {
            Dialogues[2].Play();
        }
        else if (DialogueProbabillity > 18 && DialogueProbabillity <= 24)
        {
            Dialogues[3].Play();
        }

    }
}
