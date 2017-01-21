using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePlacementController : MonoBehaviour {

    public Text placementText;
    public Text playerNameText;
    public Text scoreText;
    
    public void SetHighScoreValues(int placement, string name, int score)
    {
        placementText.text = placement.ToString();
        playerNameText.text = name;
        scoreText.text = score.ToString();
    }
}
