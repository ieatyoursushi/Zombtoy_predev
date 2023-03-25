using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour {
    bool inTornado = false;
    public GameObject coll;
    public float lifespan;
    public float speed = 4f;
    public bool inZone;
    GameObject fireBall;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Twist", 0.1f, 0.3f);
        Destroy(gameObject, lifespan);
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        if(inZone && fireBall != null)
        {
            Vector3 lookDirection = transform.position - fireBall.transform.position;
            lookDirection.y = 0f;
            fireBall.transform.localRotation = Quaternion.LookRotation(lookDirection);
        }else
        {

        }
	}
    private void OnTriggerEnter(Collider col)
    {
        EnemyProjectile enemyProjectile = col.GetComponent<EnemyProjectile>();
        fireBall = col.gameObject;
        if (enemyProjectile != null) {
            enemyProjectile.speed = 2.7f;
            inZone = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        EnemyProjectile enemyProjectile = col.GetComponent<EnemyProjectile>();
        if (enemyProjectile != null)
        {
            enemyProjectile.speed = 3.8f;
            inZone = false;
        }
    }
    void Twist()
    {
        LayerMask mask = LayerMask.GetMask("Shootable");
        Collider[] enemies = Physics.OverlapSphere(transform.position, 4f, mask);
        foreach(Collider col in enemies)
        {
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(3, col.transform.position);
                col.gameObject.GetComponent<Rigidbody>().AddForce(col.gameObject.transform.position - transform.position * 12f * Time.deltaTime);
                enemyHealth.SlowEffect_Duration(0.3f);
                enemyHealth.SlowEffect(0.2f);
            }
        }
        Collider[] ndSphere = Physics.OverlapSphere(transform.position, 10f, mask);
        foreach(Collider col in ndSphere)
        {
            GameObject target = col.GetComponent<GameObject>();
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(2, col.transform.position);
            }
        }
    }
}
public class Vornado : MonoBehaviour 
{
     
}
