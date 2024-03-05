using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab; 
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get {return isPlaceable;} }

    GriadManager griadManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        griadManager = FindObjectOfType<GriadManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if(griadManager != null)
        {
            coordinates = griadManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                griadManager.BlockNode(coordinates);
            }
        }
    }



    void OnMouseDown() 
    {
        if(griadManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isPlaced = towerPrefab.CreatTower(towerPrefab, transform.position);
            // Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
            griadManager.BlockNode(coordinates);
        }
    }

}
