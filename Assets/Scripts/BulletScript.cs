using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	private int speed = 10;
	private int damage = 25;
	
	//public GameObject explosion;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<enemyScript>().TakeDamage(damage);
			Explode();
		}
	}

	void Explode(){
		//Instantiate (explosion, this.transform.position, this.transform.rotation);
		Destroy (this.gameObject);
	}
}
