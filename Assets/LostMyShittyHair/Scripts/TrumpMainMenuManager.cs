using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpMainMenuManager : MonoBehaviour {
    public float offset;
    private Vector3 originalPosition;
    private Vector3 endPosition;
    private Vector3 currentPosition;

    private Vector3 startMarker;
    private Vector3 endMarker;

    private float movementCurrentTimer = 3f;
    private float movementTime = 0;
    public float maxRandomTimer = 5f;
    public float minRandomTimer = 3f;

    private float distance = 0;
    public float speed = 1;

    // Use this for initialization
    void Start () {
        currentPosition = gameObject.transform.position;
        originalPosition = currentPosition;
        startMarker = currentPosition;
        endPosition = new Vector3(startMarker.x + offset, startMarker.y, startMarker.z);
        endMarker = endPosition;
        distance = Vector3.Distance(startMarker, endMarker);
    }
	
	// Update is called once per frame
	void Update () {


        float distCovered = (movementTime - movementCurrentTimer) * speed;
        float fracJourney = distCovered / distance;

        if (transform.position != endMarker)
        {
            movementTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
        else
        {
            movementTime = 0;
            float rand = Random.Range(minRandomTimer, maxRandomTimer);
            movementCurrentTimer = rand;

            if (startMarker == originalPosition)
            {
                gameObject.transform.rotation = Quaternion.Euler(0,180,0);
                startMarker = endPosition;
                endMarker = originalPosition;
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                startMarker = originalPosition;
                endMarker = endPosition;
            }
        }
    }
}
