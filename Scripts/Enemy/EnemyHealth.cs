using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    public GameObject deathParticle;
    public Slider EnemyBar;
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    public bool isDead;
    bool effected = false;
    bool isSinking;
    public bool Rocket_Resistant;
    public GameObject Camera;
    public ParticleSystem DeathParticle;
    public GameObject snowParticle;
    public GameObject HealthImage;
    NavMeshAgent navMeshAgent;
    public float NavAgent_Speed;
    float effects_Duration = 1.5f;
    float timer;
    float navSpeed;
    float size;
    public GameObject HPSlider;
    bool hpslider;
    public zombieCount ZombieCount;
    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
        navMeshAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentHealth = startingHealth;
        ZombieCount = GameObject.Find("ZombieCount").GetComponent<zombieCount>();
    }
    public float SlowEffect_Duration (float effectDuration)
    {
        effects_Duration = effectDuration;
        return effectDuration;
    }
    private void Start()
    {
        Camera = GameObject.Find("MainCamera");
        if (DeathParticle != null)
        {
            DeathParticle.Pause();
            deathParticle.SetActive(false);
        }
        if (EnemyBar != null)
        {
            EnemyBar.maxValue = currentHealth;
        }
        NavAgent_Speed = gameObject.GetComponent<NavMeshAgent>().speed;
        navSpeed = NavAgent_Speed;
        timer = effects_Duration;
        this.HPSlider.SetActive(false); 
        if(gameObject.tag == "Anti_Rocket")
        {
            Rocket_Resistant = true;
        }
    }

    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
        if(EnemyBar != null)
        {
            Vector3 FacingDirection = Camera.transform.eulerAngles;
            EnemyBar.transform.rotation = Quaternion.Euler (FacingDirection);
        }
        if(effected)
        {
            effects_Duration -= Time.deltaTime;
        }
        if (effects_Duration <= 0 && gameObject != null)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = navSpeed;
            effects_Duration = timer;
            effected = true;
        }
        if (EnemyBar != null)
        {
            EnemyBar.value = currentHealth;
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();
        this.HPSlider.SetActive(true);
        currentHealth -= amount;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();
 

        if (currentHealth <= 0)
        {
            Death ();
            this.HealthImage.GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.10f);
            gameObject.layer = LayerMask.GetMask("Default");
        }
    }
    public void SlowEffect(float amplifier)
    {
        effected = true; // starts the countdown
        gameObject.GetComponent<NavMeshAgent>().speed = navSpeed * amplifier;
 
        effects_Duration = timer;
    }
    void Death ()
    {
        isDead = true;
        this.HPSlider.SetActive(false);
        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        ScoreManager.MonsterKills += 1;
        if (DeathParticle != null)
        {
            Invoke("deathparticles" , 0.2f);
        }
        ZombieCount.entityCount--;
    }
    void deathparticles()
    {
        deathParticle.SetActive(true);
        DeathParticle.Play();
    }

    public void StartSinking ()
    {
        ScoreManager.score += scoreValue;
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
}
