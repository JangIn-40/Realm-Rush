using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    // 적들나오는 곳의 라벨을 0,0으로 설정하지 않아서 오류가 나오는듯 아예 이상한곳에 라벨이 칠해짐
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color changeColor = Color.black;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GriadManager griadManager;

    void Awake()
    {
        griadManager = FindObjectOfType<GriadManager>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinate();
        // label.color = defaultColor;
        label.enabled = false;
    }


    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinate();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void DisplayCoordinate()
    {
        if(griadManager == null) { return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / griadManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / griadManager.UnityGridSize);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetLabelColor()
    {
        // if(wayPoint.IsPlaceable == false)
        // {
        //     label.color = changeColor;
        // }
        if(griadManager == null) { return; }

        Node node = griadManager.GetNode(coordinates);
        if(node == null) { return; }

        if(!node.isWalkable)
        {
            label.color = changeColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }

    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }

    }
}
