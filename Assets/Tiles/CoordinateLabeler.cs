using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color changeColor = Color.black;

    TextMeshPro label;
    WayPoint wayPoint;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        wayPoint = GetComponentInParent<WayPoint>();
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

        ColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinate()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ColorCoordinates()
    {
        // if(wayPoint.IsPlaceable == false)
        // {
        //     label.color = changeColor;
        // }
        if(wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = changeColor;
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
