using UnityEngine;
using UnityEngine.AI;

public class Pathing : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
