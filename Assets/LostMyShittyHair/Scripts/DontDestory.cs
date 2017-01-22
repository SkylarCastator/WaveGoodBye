using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(GameObject.Find("HighLander") != null)
        {
            Destroy(gameObject, 0f);
        }
        else
        {
            gameObject.name = "HighLander";
        }

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
