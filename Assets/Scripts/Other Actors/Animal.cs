using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [Header("Way Points")]
    [SerializeField] private List<Transform> points;
    //[SerializeField] private Transform nextPoint;
    private int nextPointIndex = 0;

    [Header("Speed")]
    [SerializeField] private float speed;
    private float step;

    private void Start()
    {
        step = speed * Time.deltaTime;  //so the speed is the same on any device
        transform.position = points[nextPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //looking at point
        Vector3 dir = points[nextPointIndex].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //moving to waypoint
        transform.position = Vector2.MoveTowards(transform.position, points[nextPointIndex].position, step);

        if (transform.position == points[nextPointIndex].position)
            nextPointIndex += 1;
        
        if(nextPointIndex >= points.Count)
        {
            nextPointIndex = 0;
        }
    }
}
