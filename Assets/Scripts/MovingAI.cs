using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovingAI : MonoBehaviour
{
    [SerializeField] private float Radius = 20;
    [SerializeField] private bool DebugBool;

    private NavMeshAgent MyAgent;
    private Vector3 nextPos;
    Animator anm;

    void Start()
    {
        anm = GetComponent<Animator>();
        MyAgent = GetComponent<NavMeshAgent>();
        MyAgent.autoBraking = false; // Auto Braking'i devre dışı bırakma
        SetNextDestination();
    }

    void Update()
    {
        // Hedefe yaklaşıldığında yeni bir rastgele hedef belirleme
        if (MyAgent.remainingDistance <= MyAgent.stoppingDistance && !MyAgent.pathPending)
        {
            SetNextDestination();
        }

        // Ajanın belirli bir süre boyunca durmasını önlemek için ek kontrol
        if (MyAgent.velocity.sqrMagnitude < 0.1f && !MyAgent.pathPending)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        nextPos = GetRandomPoint(transform.position, Radius);
        MyAgent.SetDestination(nextPos);
    }

    private void OnDrawGizmos()
    {
        if (DebugBool)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, nextPos);
        }
    }

    public static Vector3 GetRandomPoint(Vector3 center, float range)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return center; // Geçerli bir nokta bulunamazsa mevcut pozisyonda kal
    }
}
