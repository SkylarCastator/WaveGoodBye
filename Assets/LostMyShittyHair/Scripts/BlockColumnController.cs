using UnityEngine;
using System.Collections;

public class BlockColumnController : MonoBehaviour {

    public GameObject[] blocks;
    public float scrollSpeed = 1;

    public bool moveUpDown = false;
    public float updownSpeed = 1f;
    public float randomMoveMax = 5;
    public float radomMoveMin = 5;

	// Use this for initialization
	void Start () {
        int selectedRandomBox = Random.Range(0, blocks.Length);
        blocks[selectedRandomBox].SetActive(false);
	}

    // Update is called once per frame
    void Update() {

        gameObject.transform.Translate(Vector2.left * scrollSpeed);
        if (moveUpDown)
        {
            //if () { }
            gameObject.transform.Translate(Vector2.up * updownSpeed);

        }
    }
}
