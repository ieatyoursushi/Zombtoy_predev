using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegen : MonoBehaviour {
    public float cooldown = 1;
    public EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
        InvokeRepeating("Regenerate", 0f, cooldown);
 
	}
	void Regenerate()
    {
        if(enemyHealth.currentHealth < enemyHealth.startingHealth && !enemyHealth.isDead) {
            enemyHealth.currentHealth += 1;
        }
    }
	// Update is called once per frame
	void Update () {
 

    }
}
