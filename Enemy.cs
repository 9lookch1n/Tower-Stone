using UnityEngine;

public class Enemy : MonoBehaviour
{
    //set up speed
    private float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        //set point array 0
        target = Waypoints.points[0];
    }

    private void Update()
    {
        //diraction = target - transform 
        Vector2 dir = target.position - transform.position;
        //speed walk enemy
        transform.Translate(dir.normalized * speed * Time.deltaTime * 0.1f ,Space.World);

        //conditions of arrival
        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            //Run method
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        //conditions of arrival
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy Object when arrived
            Destroy(gameObject);
            return;
        }
        //wavepoint more and more
        wavepointIndex++;
        //set target by waypoint
        target = Waypoints.points[wavepointIndex];
    }

}
