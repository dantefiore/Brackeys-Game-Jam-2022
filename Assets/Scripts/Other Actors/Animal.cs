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
        step = speed; //* Time.deltaTime;  //so the speed is the same on any device
        transform.position = points[nextPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //moving to waypoint
        transform.position = Vector2.MoveTowards(transform.position, points[nextPointIndex].position, step);

        if (this.gameObject.GetComponent<Animator>() != null)
            Animate(transform, points[nextPointIndex]);

        if (transform.position == points[nextPointIndex].position)
            nextPointIndex += 1;
        
        if(nextPointIndex >= points.Count)
        {
            nextPointIndex = 0;
        }
    }

    void Animate(Transform character, Transform nextPoint)
    {
        float facingDir = nextPoint.position.x - character.position.x;

        if(facingDir >=0)
        {
            character.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            character.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
