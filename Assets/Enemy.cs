using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointsIndex = 0;
    List<int> leftList = new List<int>() {1, 4, 8, 9, 10, 12, 13, 15, 18, 19};
    List<int> rightList = new List<int>() { 2, 3, 5, 6, 7, 11, 14, 16, 17, 20 };


    void Start()
    {
        target = Waypoints.points[0];
      
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            
            GetNextWayPoint();
        }
    }
    void GetNextWayPoint()
    {
        if (wavepointsIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointsIndex++;
        target = Waypoints.points[wavepointsIndex];

        if (leftList.Contains(wavepointsIndex)) transform.Rotate(0, -90, 0);
        else if (rightList.Contains(wavepointsIndex)) transform.Rotate(0, 90, 0);

        //if (wavepointsIndex == 1) transform.Rotate(0, -90, 0);
        //if(wavepointsIndex == 2) transform.Rotate(0, 90, 0);
        //if (wavepointsIndex == 3) transform.Rotate(0, 90, 0);
        //if (wavepointsIndex == 4) transform.Rotate(0, -90, 0); //turn left 
        //if (wavepointsIndex == 5) transform.Rotate(0, 90, 0); // turn right
    }
}