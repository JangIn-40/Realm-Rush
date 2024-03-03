using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float moveSpeed = 1f;

    Enemy enemy;
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject tile in tiles)
        {
            WayPoint waypoint = tile.GetComponent<WayPoint>();

            if(waypoint != null)
            {
                path.Add(waypoint);
            }

        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach(WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float endPercent = 0f;

            transform.LookAt(endPosition);

            while(endPercent < 1f)
            {
                endPercent += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, endPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinsihPath();
    }
    
    void FinsihPath()
    {
        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }
}
