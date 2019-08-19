using UnityEngine;
using System.Collections;

public class MoveToWayPoints : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    int curWaypointIndex;

    private void Update()
    {
        if (curWaypointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                waypoints[curWaypointIndex].position,
                Time.deltaTime * speed);
            transform.LookAt(waypoints[curWaypointIndex].position);
            if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
            {
                curWaypointIndex++;
            }
        }
    }
}