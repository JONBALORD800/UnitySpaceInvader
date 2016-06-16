using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int speed;
    public int lives=2;
    public GameObject laserPrefab;



    public float frequenceOfShootInseconds;

    private float frequenceOfShootPerSecond;
    private float frequenceOfShootPerframe;

    private GameObject _projectilesContainer;
    private Rigidbody2D _rb2D;

	// Use this for initialization
	void Start () 
	{
        frequenceOfShootPerSecond = 1 / frequenceOfShootInseconds;
        frequenceOfShootPerframe = frequenceOfShootPerSecond * Time.deltaTime;

        _rb2D = GetComponent<Rigidbody2D>();
        speed = Random.Range(1, 3);
        _rb2D.velocity = Vector3.down * speed;

        _projectilesContainer = GameObject.Find("ProjectilesContainer");
        if (_projectilesContainer == null)
        {
            _projectilesContainer = new GameObject("ProjectilesContainer");
        }

    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Random.value < frequenceOfShootPerframe)
        {
            Shoot();
        }
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {       
        Laser laserScript = col.GetComponent<Laser>();
        if (laserScript!=null)
        {
            print("OnTriggerEnter2D");
            GetDamage(laserScript.Damage);

        }
    }

    private void GetDamage(int damage)
    {
        lives-=damage;
        if (lives <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    private void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.transform.SetParent(_projectilesContainer.transform);
    }


}
