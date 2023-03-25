using UnityEngine;
using System.Collections.Generic;
public class ItemManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject item;
    public float spawnTime;
    public Transform[] spawnPoints;
    public int SpawnPointMax;
    float RealSpawnTime;
    public float MaximumItemNumber;
    public float ItemAmount;
    public Collider[] colliders;
    public List<Transform> SpawnPointsList = new List<Transform>();
    void Start()
    {
        //checks the entire array and adds those possible spawnpoints to the spawnpoints list.
        for(int i = 0; i < spawnPoints.Length;  i++)
        {
            SpawnPointsList.Add(spawnPoints[i]);
        }
        RealSpawnTime = Random.Range(spawnTime, spawnTime * 3);
        InvokeRepeating("Spawn", 10, RealSpawnTime);
        item.SetActive(true);
    }
    private void FixedUpdate()
    {

    }
    void Spawn()
    {
        
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, SpawnPointsList.Count);
        
 
        if(ItemAmount < MaximumItemNumber)
        {
            if (SpawnPointsList.Count > 0)
            {
                this.ItemAmount++;
                GameObject NewItem = Instantiate(item, SpawnPointsList[spawnPointIndex].position, SpawnPointsList[spawnPointIndex].rotation) as GameObject;
                if (NewItem.GetComponent<HealthPotion>() == null)
                {
                    NewItem.GetComponent<AmmoItem>().gameObjectSpawnPoint = SpawnPointsList[spawnPointIndex];
                }
                if (NewItem.GetComponent<AmmoItem>() == null)
                {
                    NewItem.GetComponent<HealthPotion>().gameObjectSpawnPoint = SpawnPointsList[spawnPointIndex];
                }

                SpawnPointsList.RemoveAt(spawnPointIndex);
            }
        } 
    }
 
}
