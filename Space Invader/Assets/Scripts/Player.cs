using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Vector3 direction;
    public int speed;
    public GameObject laserPreFab;
    public int lives = 3;
    public GameManager gMana;

    private Transform _transform;
    public float fireRate;

    private float shootTimer;
    private GameObject _projectilesContainer;

	// Use this for initialization
	void Start () {
        _transform = GetComponent<Transform>();
        _projectilesContainer = GameObject.Find("ProjectilesContainer");
        if (_projectilesContainer == null)
        {
            _projectilesContainer = new GameObject("ProjectilesContainer");
        }
	}
	
	// Update is called once per frame
	void Update () {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time > shootTimer + fireRate)
            {
                shootTimer = Time.time;
                print("Shoot");
                Shoot();
            }
            
        }
        Move();
        lives = Mathf.Max(0, lives);
    }

    private void Move()
    {
        _transform.position += direction * speed * Time.deltaTime;
    }
    private void Shoot()
    {
        GameObject laser = Instantiate(laserPreFab, _transform.position, Quaternion.identity) as GameObject;
        laser.transform.SetParent(_projectilesContainer.transform, false);
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        lives--;
        if (lives <= 0)
        {
            EndOfGame();
            Destroy(this.gameObject);
        }
    }
    private void EndOfGame()
    {
        gMana.EndGame();
    }
}
