using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float frequenceOfSpawn;
    private float spawnTimer;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > spawnTimer + Random.value * frequenceOfSpawn)
        {
            spawnTimer = Time.time;
            Vector3 spawnPosition = new Vector3(-10 + Random.value * 20, 7, 0);
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity) as GameObject;
            spawnedObject.transform.SetParent(this.transform, false);
        }
	}
}
