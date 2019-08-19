using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public Transform shootElement;
    public Transform LookAtObj;
    public int dmg = 10;
    public BulletTower bullet;
    public float shootDelay;
    bool isShoot;
    private Enemy _enemy;
    private Coroutine _shootCoroutine;

    private void Update()
    {
        var enemies = Spawner.Instance.Enemies;
        if (enemies.Count > 0)
        {
            _enemy = enemies[0];
            var  targetPosition = new Vector3(_enemy.transform.position.x, transform.position.y,
                enemies[0].transform.position.z);

            LookAtObj.transform.LookAt(targetPosition);
            if (!isShoot)
            {
                _shootCoroutine = StartCoroutine(Shoot());
            }
        }
    }

    private IEnumerator Shoot()
    {
        while (_enemy != null)
        {
            isShoot = true;
            yield return new WaitForSeconds(shootDelay);
            var b = Instantiate(bullet, shootElement.position, Quaternion.identity);
            b.target = _enemy.transform;
            b.twr = this;
            isShoot = false;
        }
        
        StopCoroutine(_shootCoroutine);
    }
}