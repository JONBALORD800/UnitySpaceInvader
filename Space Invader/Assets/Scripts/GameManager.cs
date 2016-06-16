using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public LevelManager lvlManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void EndGame()
    {
        print("End of Game");
        Invoke("LoadEndScene",2);
    }
    private void LoadEndScene()
    {
        CancelInvoke();
        lvlManager.LoadNextLevel();
    }
}
