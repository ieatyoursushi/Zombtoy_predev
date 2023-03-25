using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color healFlashColor = new Color(0f, 1f, 0f, 0.1f);
    public GameObject Shotgun;
    public float Stamina = 1f;
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    public bool isDead;
    bool damaged;
    public GameObject StaminaSlider;
    GameObject StaminaSliderWhole;
    public float sprint_Speed;
    private float default_Speed;
    public bool isSprinting;
    GameObject firstperson;
    public Animator animator;
    CameraMovement cameraMovement;
    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        StaminaSliderWhole = GameObject.Find("StaminaSlider");
    }
    private void Start()
    {
        if (playerMovement == null)
        {
            cameraMovement = GetComponent<CameraMovement>();
        }
        if (playerMovement != null)
        {
            default_Speed = playerMovement.speed;
        } else
        {
            default_Speed = GetComponent<CameraMovement>().playerSpeed;
        }
        if (playerMovement != null)
        {
            sprint_Speed = playerMovement.speed * 1.20f;
        } else
        {
            sprint_Speed = GetComponent<CameraMovement>().playerSpeed * 1.20f;
        }
        firstperson = GameObject.Find("FirstPerson");
    }
    private void FixedUpdate()
    {
        healthSlider.value = currentHealth; 
    }
    void Update ()
    {
         
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        
        if(healing)
        {
            damageImage.color = new Color(0f, 1f, 0f, 0.15f);
        } else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        healing = false;
        Sprint();

        StaminaSlider.transform.localScale = new Vector3(Stamina, 1, 1);
        if(StaminaSlider.transform.localScale.x >= 1)
        {
            StaminaSliderWhole.SetActive(false);
        } else
        {
            StaminaSliderWhole.SetActive(true);
        }
    }
    bool healing;
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            if (Stamina > 0)
            {
                if (playerMovement != null)
                {
                    playerMovement.speed = Mathf.Lerp(playerMovement.speed, sprint_Speed, 0.2f);
                } else
                {
                    cameraMovement.playerSpeed = Mathf.Lerp(cameraMovement.playerSpeed, sprint_Speed, 0.2f);
                }
                Stamina -= Time.deltaTime * 0.5f;
                animator.speed = 1.25f;
            }
            else if (Stamina <= 0)
            {
                if (playerMovement != null)
                {
                    playerMovement.speed = default_Speed;
                } else
                {
                    cameraMovement.playerSpeed = default_Speed;
                }
                animator.speed = 1f;
            }
        }
        else
        {
            isSprinting = false;
            animator.speed = 1f;
            if (playerMovement != null)
            {
                playerMovement.speed = default_Speed;
            }  else
            {
                GetComponent<CameraMovement>().playerSpeed = default_Speed;
            }
        }
        
        if (!isSprinting && Stamina <= 1)
        {
            Stamina += Time.deltaTime * 0.15f;
        }
    }

    public void Heal(int amount)
    {
        healing = true;

        healthSlider.value = currentHealth;
        
        currentHealth += amount;

        if(currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }
    }
    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    public Inventory inventory;
    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        } else
        {
            GetComponent<CameraMovement>().enabled = false;
        }
        playerShooting.enabled = false;
        GameObject.Find("Fill").GetComponent<Image>().color = Color.white;
        //Destroy(Shotgun); 
        //GameObject.Find("RocketLauncher").GetComponent<RocketLauncher>().enabled = false;
        //GameObject.Find("Pistol").GetComponent<Pistol>().enabled = false;
    }

    public void RestartLevel ()
    {
        SceneManager.LoadScene (2);
    }
}
