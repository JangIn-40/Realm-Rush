using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GriadManager griadManager;
    Dictionary<Vector2Int, Node> grid;

    void Awake()
    {
        griadManager = FindObjectOfType<GriadManager>();
        if(griadManager != null)
        {
            grid = griadManager.Grid;
        }
    }

    void Start()
    {
        ExplorNeighbors();
    }

    void ExplorNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
        
            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                grid[neighborCoords].isExplored = true;
            }
        }
    }
}
