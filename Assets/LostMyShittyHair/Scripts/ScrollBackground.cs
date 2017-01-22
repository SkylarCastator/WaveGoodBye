using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private RectTransform GridObjectTransform;
    private float posXOriginal = 0;
    public float movementSpeed;
    public float maxXPosition;
    void Start()
    {
        GridObjectTransform = gameObject.GetComponent<RectTransform>();
        posXOriginal = GridObjectTransform.position.x;
    }

    void Update()
    {
        if (GridObjectTransform.position.x < maxXPosition)
        {
            GridObjectTransform.position = new Vector3(posXOriginal, GridObjectTransform.position.y, GridObjectTransform.position.z);
        }
        else
        {
            GridObjectTransform.position = new Vector3(GridObjectTransform.position.x + movementSpeed, GridObjectTransform.position.y, GridObjectTransform.position.z);
        }
    }
}