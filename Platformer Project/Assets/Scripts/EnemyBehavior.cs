using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float chaseDistance = 5f;
    Rigidbody2D rb;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    AIPath pathFinder;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        
        if (path.GetTotalLength() < chaseDistance)
        {
            pathFinder.maxSpeed = speed;
        }
        else
        {
            pathFinder.maxSpeed = 0;
        }
    }

    //void ChaseTarget()
   // {
   //     Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - rb.position;
    //    if(direction.magnitude < nextWaypointDistance)
    //    {
    //        currentWaypoint++;
   //     }
     //   direction.Normalize();
     //   Vector2 velocity = direction * speed * Time.deltaTime;
      //  rb.velocity = velocity;
    //}
}
