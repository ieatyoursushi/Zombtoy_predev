using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;
    public zombieCount ZombieCount;
    private float ShortestSpawnTime;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
        ZombieCount = GameObject.Find("ZombieCount").GetComponent<zombieCount>();
        ShortestSpawnTime = spawnTime * 0.60f;
    }
    private void Update()
    {
    }
    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if (ZombieCount.entityCount <= ZombieCount.maximumEntities)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            ZombieCount.entityCount++;
            if (gameObject.tag != "GIANT" && spawnTime >= ShortestSpawnTime)
            {
                spawnTime = spawnTime * 0.99f;
            }
        }
    }
}
