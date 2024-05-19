using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericRandomPointer : MonoBehaviour
{
    public static Vector3 RPointGe(Vector3 startPoint, float Radius)
    {
        Vector3 Dir = Random.insideUnitSphere * Radius;
        Dir += startPoint;
        NavMeshHit hit;
        Vector3 FinalPos = Vector3.zero;

        if (NavMesh.SamplePosition(Dir, out hit, Radius, 1))
        {
            FinalPos = hit.position;
        }
        return FinalPos;
    }
}
