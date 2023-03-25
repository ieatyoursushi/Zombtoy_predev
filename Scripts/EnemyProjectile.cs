using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class EnemyProjectile : MonoBehaviour {
    Vector3 bulletMovement;
    public float speed;
    public int DamagePerShot;
    RaycastHit shot;
    RaycastHit shootHit;
    public bool hit = false;
    bool collided = false;
    public GameObject particle;
     
    // Use this for initialization
    void Start () {
        GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject, 10f);
    }
    void attack()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, 0.6f);
        foreach (Collider col in collider)
        {
            if (hit == false)
            {
                collided = true;
                PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
                if (playerHealth != null && !playerHealth.isDead)
                {
                    playerHealth.TakeDamage(DamagePerShot);
                    hit = true;
                    Destroy(gameObject);
                }
            }
        }
 
    }
    // Update is called once per frame
    void FixedUpdate () {
        bulletMovement.Set(0f, 0f, speed);
        transform.Translate(bulletMovement * speed * Time.deltaTime);
        attack();
    }
}
