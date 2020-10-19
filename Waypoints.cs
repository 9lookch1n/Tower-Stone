using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{   
    //Array Transform points
    public static Transform[] points;

    private void Awake()
    {
        //loop for point used to set the position of a point.
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
           points[i] = transform.GetChild(i);
        }
    }

}
