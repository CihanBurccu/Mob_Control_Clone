using UnityEngine;
using UnityEngine.AI;

public class PlayerAgents : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject target;
    public float destroyTime = 0.2f;
   
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemySpawner");
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    { 
        Move(target.transform.position);
    }

    private void Move(Vector3 location)
    {
        agent.SetDestination(location);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject, destroyTime);
            Destroy(other.gameObject, destroyTime);
        }
        if (other.gameObject.CompareTag("EnemySpawner"))
        {
            Destroy(this.gameObject, destroyTime);
            target.GetComponent<EnemyManager>().enemySpawnerHealth--;

            if (target.GetComponent<EnemyManager>().enemySpawnerHealth == 0)
            {
                target.GetComponent<EnemyManager>().enemySpawnCount = 0;
                GameManager.instance.SetSuccessMenuState(true);
            }
        }
    }
}
