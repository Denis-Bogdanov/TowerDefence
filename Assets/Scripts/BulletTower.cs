using UnityEngine;
using System.Collections;

public class BulletTower : MonoBehaviour
{
    public float Speed;
    public Transform target;
    public Transform LookAtBul;

    public GameObject impactParticle; // bullet impact

    //public Transform ImpactLocation; // bullet impact
    public Vector3 impactNormal; // bullet impact
    public Tower twr;

    float i = 0.2f;

    public Enemy enemy;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            LookAtBul.transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var enemy1 = other.GetComponent<Enemy>();
        if (enemy1 == null)
            return;
        
        enemy1.SetDamage(25f);
        Destroy(gameObject);
        
//        if (other.gameObject.transform == target)
//        {
//            Destroy(gameObject, i);
//            impactParticle =
//                Instantiate(impactParticle, transform.position,
//                    Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
//            impactParticle.transform.parent = target.transform;
//            Destroy(impactParticle, 3);
//            return;
//        }
    }
}