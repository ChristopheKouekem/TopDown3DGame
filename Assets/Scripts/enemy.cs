using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int currentIndex;
    public Vector3[] goals;
    public float speed = 3f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 0.5f; // WICHTIG: Stopp-Distanz setzen
        currentIndex = 0;

        if (goals.Length > 0)
        {
            // Prüfe ob Goal auf NavMesh liegt
            NavMeshHit hit;
            if (NavMesh.SamplePosition(goals[currentIndex], out hit, 1.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
            else
            {
                Debug.LogError("Goal ist nicht auf der NavMesh: " + goals[currentIndex]);
            }
        }
    }

    void Update()
    {
        if (goals.Length == 0) return;

        // Wenn Agent steckt oder keinen Pfad hat, neu berechnen
        if (agent.velocity.magnitude < 0.1f && agent.hasPath)
        {
            agent.SetDestination(goals[currentIndex]);
        }

        // Zielerreichung prüfen
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending && agent.hasPath)
        {
            if (currentIndex + 1 < goals.Length)
            {
                currentIndex++;

                // Nächstes Goal auf NavMesh prüfen
                NavMeshHit hit;
                if (NavMesh.SamplePosition(goals[currentIndex], out hit, 1.0f, NavMesh.AllAreas))
                {
                    agent.SetDestination(hit.position);
                }
            }
        }
    }

    // Debug: Zeige Goals in der Szene
    void OnDrawGizmosSelected()
    {
        if (goals != null)
        {
            Gizmos.color = Color.red;
            foreach (Vector3 goal in goals)
            {
                Gizmos.DrawWireSphere(goal, 0.3f);
            }
        }
    }
}