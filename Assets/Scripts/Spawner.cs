using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy SpawnObject;
    public float SpawnTime = 1f;

    private float _timer = 0;
    public List<Enemy> Enemies { get; }

    private static Spawner _instance;

    private Spawner()
    {
        Enemies = new List<Enemy>();
    }

    public static Spawner Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void EnemyDestroyed(Enemy enemy)
    {
        Enemies.Remove(enemy);
        Debug.LogError("Umer");
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            var enemy = Instantiate(SpawnObject, transform.position, transform.rotation);
            enemy.SetSpawner(this);
            Enemies.Add(enemy);
            _timer = SpawnTime;
        }
    }
}