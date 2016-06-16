using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleUIManager : MonoBehaviour {

    public Text livesText;
    public Player player;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = "Lives: " + player.lives;
	}
}
