using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriadManager : MonoBehaviour
{
    // 딕셔너리
    // Key와 Value가 있다.Key는 null이 될수없고 Value는 null이 될수도 있다. 
    // Key를 단어 Value를 단어의 설명이라 생각해도 된다.
    // Key는 유일하기때문에 비교적 단순한 데이터 유형을 사용함
    // Value는 훨씬 더 복잡한 유형을 가질수있다.
    // Key에서 Value를 찾는것은 빠르지만
    // Value에서 Key를 찾는것은 매우 느리다.
    [SerializeField] Vector2Int gridSize;
    [Tooltip("World Grid Size - Should match UnityEditor snap settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid {get { return grid; }}

    void Awake()
    {
        CreateGrid();
    }
    
    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = false;
        }
    }

    public void RestNodes()
    {
        foreach(KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.coonectTo = null;
            entry.Value.isExplored = false;
            entry.Value.isPath = false;
        }
    }
    
    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }
}
