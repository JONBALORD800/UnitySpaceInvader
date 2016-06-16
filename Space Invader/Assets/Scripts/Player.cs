using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Vector3 direction;
	public Transform Camera;
    public int speed;
	public AudioSource Sound;
	public AudioClip Explosion, FireLaser;
    public GameObject laserPreFab;
    public int lives = 3;
    public GameManager gMana;
	public ParticleSystem ReacteurPlayer;
    private Transform _transform;
    public float fireRate;

    private float shootTimer;
    private GameObject _projectilesContainer;


	// Use this for initialization
	void Start ()
	{
		ReacteurPlayer.Stop();
        _transform = GetComponent<Transform>();
        _projectilesContainer = GameObject.Find("ProjectilesContainer");
        if (_projectilesContainer == null)
        {
            _projectilesContainer = new GameObject("ProjectilesContainer");
        }
	}
	
	// Update is called once per frame
	void Update () 
	{			
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
		if (Input.GetKeyDown ("up")) 
		{
			ReacteurPlayer.Play ();
		} 
		if(Input.GetKeyUp ("up"))
		{
			ReacteurPlayer.Stop ();
		}
    }
    private void Shoot()
    {
		Sound.PlayOneShot (FireLaser,0.5f);
        GameObject laser = Instantiate(laserPreFab, _transform.position, Quaternion.identity) as GameObject;
        laser.transform.SetParent(_projectilesContainer.transform, false);
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        lives--;
		StartCoroutine (TimeShake());
        if (lives <= 0)
        {
			Sound.PlayOneShot (Explosion,0.5f);
			Invoke("EndOfGame",1f);
           
        }
    }
    private void EndOfGame()
    {
		Destroy(this.gameObject);
        gMana.EndGame();
    }
	IEnumerator TimeShake() 
	{
		for(int i=0;i<6;i++)
		{
			Camera.Translate (Random.Range(-0.5f,0.5f),0f,0f);
			yield return new WaitForSeconds(0.005f);
		}

		//yield return new WaitForSeconds(0.1f);
		Camera.position = new Vector3 (0f,0f,-10f);

	}

}
