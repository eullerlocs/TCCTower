using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int WavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = WayPoints.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.startSpeed;

        transform.LookAt(target);
    }



    void GetNextWayPoint()
    {
        if (WavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        WavepointIndex++;
        target = WayPoints.points[WavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Health -= 10;
        Destroy(gameObject);
    }
}
