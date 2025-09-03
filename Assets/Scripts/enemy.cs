using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int currentIndex;
    public Vector3[] goals;
    public float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[currentIndex]);
    }
    float count;
    Vector3 direction = Vector3.back;
    void Update()
    {
        float distance = (goals[currentIndex] - transform.position).magnitude;

        if (distance < 0.5f && currentIndex + 1 < goals.Length)
        {
            currentIndex++;
            agent.SetDestination(goals[currentIndex]);
        }
    }
}
