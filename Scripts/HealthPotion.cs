using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPotion : MonoBehaviour {
    public PlayerHealth playerHealth;
    public int heal;
    public AudioSource healing;
    public Transform gameObjectSpawnPoint;
    // Use this for initialization
    void Start () {
        // will find the components that are required
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        healing = GameObject.Find("HealthAudio").GetComponent<AudioSource>();
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public ItemManager itemManager;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            playerHealth.Heal(heal);
            healing.Play();
            this.itemManager.ItemAmount--;
            ScoreManager.score += 3;
            StartCoroutine(DestroyAndAddSpawnPoint());
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
    IEnumerator DestroyAndAddSpawnPoint()
    {
        yield return new WaitForSeconds(0f);
        for (int i = 0; i < itemManager.spawnPoints.Length; i++)
        {
            if (itemManager.spawnPoints[i] == gameObjectSpawnPoint)
            {
                itemManager.SpawnPointsList.Add(itemManager.spawnPoints[i]);
            }
        }
        Destroy(gameObject);
    }
}
