using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorTest : MonoBehaviour {
    public Transform [] spawnPositions;
    public GameObject dot;
    public PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnItem", 1f, 1f);
    }
    Vector3 randomPosition()
    {
        float x, y, z;
        x = Random.Range(spawnPositions[0].position.x, spawnPositions[1].position.x);
        y = Random.Range(spawnPositions[0].position.y, spawnPositions[1].position.y);
        z = Random.Range(spawnPositions[0].position.z, spawnPositions[1].position.z);
        return new Vector3(x, y, z);
    }
    // Update is called once per frame
    void Update() {
         

    }
    void spawnItem()
    {
        Instantiate(dot, randomPosition(), transform.rotation);
    }
}
