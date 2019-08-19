using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float maxLife = 100f;

    private Transform _waypoints;
    private Transform _waypoint;
    private int _waypointIndex = -1;
    private float _life;
    private Spawner _spawner;

    public void SetSpawner(Spawner spawner)
    {
        _spawner = spawner;
    }
    void Start()
    {
        _waypoints = GameObject.Find("WayPoints").transform;
        NextWaypoint();

        _life = maxLife;
    }

    void Update()
    {
        Vector3 dir = _waypoint.transform.position - transform.position;
        dir.y = 0;

        float speedy = Time.deltaTime * speed;
        transform.Translate(dir.normalized * speedy);

        if (dir.magnitude <= speedy)
            NextWaypoint();
    }

    void NextWaypoint()
    {
        _waypointIndex++;

        if (_waypointIndex >= _waypoints.childCount)
        {
            Destroy(gameObject);
            return;
        }

        _waypoint = _waypoints.GetChild(_waypointIndex);
    }

    public void SetDamage(float value)
    {
        _life -= value;
        if (!(_life <= 0))
            return;
        
        Destroy(gameObject);
        _spawner.EnemyDestroyed(this);
    }
}