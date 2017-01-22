using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {
    public LostMyShittyHairManager gameManager;
    public AudioClip[] crashingAudioClips;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update () {
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.AddScorePoint();
            int rand = Random.Range(0, crashingAudioClips.Length);
            audioSource.PlayOneShot(crashingAudioClips[rand]);
        }
    }
}
