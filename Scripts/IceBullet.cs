using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IceBullet : MonoBehaviour {
    public GameObject pistolTransform;
    Vector3 bulletMovement;
    public float speed;
    public int DamagePerShot;
    RaycastHit shot;
    RaycastHit shootHit;
    public bool hit = false;
    bool collided = false;
    bool found_Target = false;
    bool effected = false;
    private GameObject firstperson;
    bool rotating = false;
    bool inRange = false;
    public GameObject target;
    public float NavAgent_Speed;
    float timer;
    LayerMask mask;
	// Use this for initialization
	void Start () {
        pistolTransform = GameObject.Find("Pistol");
        firstperson = GameObject.Find("FirstPerson");
        this.target = null;
    } 
	void Trail()
    {
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
	// Update is called once per frame
	void FixedUpdate () {
        bulletMovement.Set(0f, 0f, speed);
        if (!collided)
        {
            this.transform.Translate(bulletMovement * speed * Time.deltaTime);
        }
        attack();
        if(rotating && target != null)
        {
            Rotate();
        }
    }
    private void Update()
    {
        
    }
    void attack()
    {
        LayerMask mask = LayerMask.GetMask("Shootable");
        if (Physics.Raycast(transform.position, transform.forward, out shot, 1f, mask) && hit == false)
        {
            inRange = true;
            collided = true;
            EnemyHealth enemyHealth = shot.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(DamagePerShot, shot.point);
                if (target != null)
                {
                    if (!effected)
                    {
                        enemyHealth.SlowEffect_Duration(1.5f);
                        enemyHealth.SlowEffect(0.6f); // enemy only keeps 55% of its speed
                        effected = true;
                    }
                }
                hit = true;
            }
        }
        if (collided)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            target = col.gameObject;
 
            if (target != null && !enemyHealth.isDead)
            {
                rotating = true;
            }
        }

    }
    /*
    void homing()
    {
        inRange = true;
        LayerMask mask = LayerMask.GetMask("Shootable");
        if (Physics.SphereCast(this.transform.position, 2f, this.transform.forward * speed * 2f * Time.deltaTime, out this.shootHit, 2f, mask) && !found_Target)
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null && found_Target == false)
            {
               
                found_Target = true;
            }
            if (enemyHealth != null)
            {
                if (target != null && !enemyHealth.isDead )
                {
                    this.Rotate();
                }
            }
        }
        else
        {
            inRange = false;
        }
    }
    */
    void Rotate()
    {

        Vector3 lookDir = target.transform.position - gameObject.transform.position;
        if (firstperson == null)
        {
            lookDir.y = 0f;
        }
        gameObject.transform.localRotation = Quaternion.LookRotation(lookDir);
        transform.position += 3 * lookDir * Time.deltaTime;
    }
 
}
