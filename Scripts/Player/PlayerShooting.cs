using UnityEngine;
using UnityEngine.UI;
public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 60;
    public float timeBetweenBullets = 0.015f;
    public float range = 100f;
    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public Ammo ammoScript;
    public float reloadTimer;
    public PlayerHealth playerHealth;
    RaycastHit aim;
    GameObject aimCross;
    bool inRange;
    Pause pause;
    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        aimCross = GameObject.Find("Cross");
        pause = GameObject.Find("HUDCanvasd").GetComponent<Pause>();
    }


    void Update()
    {
 
        timer += Time.deltaTime;
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
        if (aimCross != null)
        {
            if (Physics.Raycast(transform.position, transform.forward, out aim, range, shootableMask))
            {
                EnemyHealth enemyHealth = aim.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    inRange = true;
                    Debug.Log(inRange);

                }
                else if (enemyHealth == null)
                {
                    inRange = false;
                }
            }
            if (pause.isPaused)
            {
                aimCross.SetActive(false);
            }
            else
            {
                aimCross.SetActive(true);
            }
        }
    }
 
    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        if (ammoScript.ammo > 0 && ammoScript.ammoText != null && !ammoScript.ReloadCheck.reload && !playerHealth.isDead)
        {
            ammoScript.ammo--;

            timer = 0f;
            gunAudio.Play();

            gunLight.enabled = true;

            gunParticles.Stop();
            gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}
