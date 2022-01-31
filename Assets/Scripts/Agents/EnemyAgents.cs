using UnityEngine;
using UnityEngine.AI;

public class EnemyAgents : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public float destroyTime = 0.2f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerSpawner");
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
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject, destroyTime);
            Destroy(other.gameObject, destroyTime);
        }

        if (other.gameObject.CompareTag("PlayerSpawner"))
        {
            Destroy(this.gameObject, destroyTime);
            target.GetComponent<PlayerManager>().playerSpawnerHealth--;

            if (target.GetComponent<PlayerManager>().playerSpawnerHealth == 0)
            {
                target.GetComponent<PlayerManager>().enabled = false;
                GameManager.instance.SetFailMenuState(true);
            }
        }
    }
}
