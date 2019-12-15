using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{
    [Header("General")]

    [Tooltip("How fast the object should move between waypoints.")]
    [Range(0.001f, 1f)] [SerializeField] private float lerpSpeed = 1f;

    [Tooltip("List of waypoints for the object to move towards.")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    

    private void Update() 
    {
        transform.position = Vector3.Lerp(transform.position, waypoints[1].position, .01f);
    }

    private void OnDrawGizmos() 
    {
        if (waypoints.Count > 0)
        {
            Gizmos.color = Color.blue;

            foreach (Transform T in waypoints)
                Gizmos.DrawSphere(T.position, .1f);

            Gizmos.color = Color.white;

            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
        }
    }
}
    