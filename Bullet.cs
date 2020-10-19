using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Singleton<Bullet>
{
    //Set up target
    private Transform target;

    //Set up speed
    public float speed = 10;

    public void Seek(Transform _target)
    {
        //set target to be the same as _target 
        target = _target ;
    }    

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            //Destroy Bullet
            Destroy(gameObject);
            return;
        }

        //Set location diraction
        Vector3 dir = target.position - transform.position;
        //speed
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //Use Method
            HitTarget();
            return;
        }
        //space World
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        //Destroy target
        Destroy(target.gameObject);
        //Manager currency +2
        GameManager.Instance.Currency += 2;
        //Destroy Bullet
        Destroy(gameObject);
    }
}
