using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

    public float speed;
    private Rigidbody2D _rb2D;
    public int damage = 1;
    

    public int Damage { get { return damage; } }
                                       // Use this for initialization
    void Start () {
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.velocity = Vector3.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }
}
