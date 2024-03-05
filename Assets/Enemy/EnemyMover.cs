using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 5f)] float moveSpeed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GriadManager griadManager;
    Pathfinder pathfinder;
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        griadManager = FindObjectOfType<GriadManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void FindPath()
    {
        path.Clear();
        path = pathfinder.GetNewPath();
    }

    void ReturnToStart()
    {
        transform.position = griadManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = griadManager.GetPositionFromCoordinates(path[i].coordinates);
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
