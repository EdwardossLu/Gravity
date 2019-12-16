using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSystem : MonoBehaviour
{
    [Header("General")]

    [Tooltip("How fast the object should move between waypoints.")]
    [Range(0.1f, 10f)] [SerializeField] private float speed = 1f;

    [Tooltip("List of waypoints for the object to move towards.")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    private int _point = 0;
    private bool _waypointDirection = false;
    

    private void Awake() 
    {
        if (_point != 0) _point = 0;
    }

    private void Update() 
    {
        MoveToNewWaypoint();
    }

    private void MoveToNewWaypoint()
    {
        /*TODO:  Make this system move dynamic for future use.
                       Remove hard coded values. */ 
                       
        float waypointMoveSpeed = speed * Time.deltaTime;

        if (!_waypointDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[1].position, waypointMoveSpeed);

            if (Vector3.Distance(transform.position, waypoints[1].position) < 0.001f)
            {
                _waypointDirection = true;
            }
        }
        else if (_waypointDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[0].position, waypointMoveSpeed);

            if (Vector3.Distance(transform.position, waypoints[0].position) < 0.001f)
            {
                _waypointDirection = false;
            }
        }
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
    