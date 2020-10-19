using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    private Transform target;

    //Set Header in inspector
    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireContdown = 0f;

    //Set Header in inspector
    [Header("Setup Firlds")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        //using Target
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        // Find the Tag and keep doing it using Loop Foreach.
        //Follow the monster
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Use Engine about mathematics
        float shortrstDistance = Mathf.Infinity;
        //GameObject = null
        GameObject nearestEnemy = null;

        //Loop forEach
        foreach (GameObject enemy in enemies)
        {
            // tracking conditions
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortrstDistance)
            {
                shortrstDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //Check monster approach and Radius
        if (nearestEnemy != null  && shortrstDistance <= range)
        {
            //set up target is nearestEnemy
            target = nearestEnemy.transform;
        }
        else
        {
            //set up target is null
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //target == null everytime
        if (target == null)
        {
            return;
        }

        // dir = diraction
        //Target lock o
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //shoot
        if (fireContdown <= 0f)
        {
            //run method Shoot
            Shoot();
            //delay shoot 1 sec / 1f
            fireContdown = 1f / fireRate;
        }
        //fireContdown decrease
        fireContdown -= Time.deltaTime;
    }
    void Shoot()
    {
        //set tracking conditions for bullet
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            //bullet target
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}

