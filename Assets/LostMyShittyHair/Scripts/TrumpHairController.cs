using UnityEngine;
using System.Collections;

public class TrumpHairController : MonoBehaviour {

    public LostMyShittyHairManager sceneManager;
    public Vector2 jumpForce = new Vector2(0, 50000);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
            body.velocity = Vector2.zero;
            body.AddForce(jumpForce);
        }

        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
          //  Die();
        }
    }

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    void Die()
    {
        //Popup gameover screen
        sceneManager.GameOver();
    }
}
