using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    Vector3 rocketMovement;
    Vector3 ExplosionPosition;
    public float speed;
    public GameObject playerTransform;
    public GameObject Rockets;
    public Transform rocketLauncher;
    public ParticleSystem explosion;
    public ParticleSystem Trail;
    public LayerMask shootable;
    bool collided = false;
    bool exploded = false;
    bool absorbed;
    public AudioSource ExplosionSound;
    public int DamagePerShot;
    public int ExplosionDamage;
    bool stopMovement = false;
    bool hit;
    bool ExplosiveHit;
    RaycastHit shootHit;
    RaycastHit rayHit;
    Ray ray = new Ray();
    EnemyHealth enemyHealth;
    public GameObject ExplideLight;
    float LightRange = 0f;
    public AudioSource block;
    public float DestroyTime;
    public float explodeRadius;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.Find("Player");
        rocketLauncher = GameObject.Find("RocketLauncher").GetComponent<Transform>();
 
        explosion.Pause();
        ExplosionSound = GameObject.Find("ExplosionSound").GetComponent<AudioSource>();
        hit = false;
        Trail = GetComponentInChildren<ParticleSystem>();
        block = GameObject.Find("block").GetComponent<AudioSource>();
        Destroy(gameObject, 30f);
    }
 
	// Update is called once per frame
	void FixedUpdate() {
        rocketMovement.Set(0f, 0f, speed);
        if (!stopMovement)
        {
            gameObject.transform.Translate(rocketMovement * speed * Time.deltaTime);
        }
    }
    private void Update()
    {
        RocketCollision();

        if (collided)
        {
 
            if (!exploded)
            {
                explode();
                exploded = true;
            }
 
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            explosion.Play();
            if (absorbed)
            {
                explosion.transform.localScale = new Vector3(2f, 2f, 2f);
            }
            Destroy(gameObject, DestroyTime);
            stopMovement = true;
            InvokeRepeating("LightLerp", 0f, 0.03f);
        }

    }
    bool lighting = false;

    void LightLerp()
    {

        ExplideLight.GetComponent<Light>().range = LightRange;
        if (lighting == false)
        {
            LightRange+=4;
            
        } else
        {
            if (LightRange != 0)
            {
                LightRange--;
            }
        }
        if(LightRange >= 20)
        {
            lighting = true;
        }
    }
    void RocketCollision()
    {
        //for raycast
        ray.origin = transform.position;
        ray.direction = Vector3.forward;
        //for spherecast

        LayerMask mask = LayerMask.GetMask("Shootable");
        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out shootHit,0.3f, mask) && hit == false)
        {
            hit = true;
            ExplosionSound.Play();
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            //checks if there is an enemyhealth script
            if (enemyHealth != null && !enemyHealth.Rocket_Resistant)
            {
                enemyHealth.TakeDamage(DamagePerShot, shootHit.point);
            }
            else if (enemyHealth != null)
            {
                if (enemyHealth.Rocket_Resistant)
                {
                    ExplosionSound.Stop();
                    absorbed = true;
                    block.Play();
                }
            }

            collided = true;
        }
        else
        {
            collided = false;
        }
    }
 
    void explode()
    {
        LayerMask mask = LayerMask.GetMask("Shootable");
        PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        ExplosionPosition = gameObject.transform.position;
        Collider[] explosionRadius = Physics.OverlapSphere(transform.position, explodeRadius, mask);
 
        foreach (Collider col in explosionRadius)
        {
            if (absorbed)
                return;
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null && ExplosiveHit == false && !enemyHealth.Rocket_Resistant)
            {
                enemyHealth.TakeDamage(ExplosionDamage, ExplosionPosition);
            } else if(enemyHealth != null)
            {
                if (enemyHealth.Rocket_Resistant)
                {
                    block.Play();
                }
            }
        }
    }

    void notActive()
    {
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        Gizmos.DrawSphere(transform.position, 3f);
    }
}
