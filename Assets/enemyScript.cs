using UnityEngine;
using System.Collections;
using System;

public class enemyScript : MonoBehaviour {

	public int hp;
	public float speed;

	void Start(){
		Destroy (this.gameObject, 12);
	}

	private void Update () {
		this.transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);
	}

	public void TakeDamage(int dmg){
		hp -= dmg;
		//Debug.Log (hp);
		if (hp <= 0) {
			Death();
		}
	}
	private void Death(){
		//Debug.Log("i'm dead");
		Destroy (this.gameObject);
	}
}
