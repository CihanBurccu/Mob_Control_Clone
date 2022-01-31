using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text healthText;
    public GameObject enemy;
    public Transform enemyParent;
    public GameObject enemySpawnPos;
    public int enemySpawnCount;
    public int enemySpawnTime;
    public int enemySpawnerHealth;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        healthText.text = enemySpawnerHealth.ToString();
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < enemySpawnCount; i++)
            {
                Instantiate(enemy, enemySpawnPos.transform.position, Quaternion.identity, enemyParent);
            }
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }
}
