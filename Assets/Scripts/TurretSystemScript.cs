using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSystemScript : MonoBehaviour {
	
	public GameObject gun;
	public GameObject bullet;
	public GameObject bulletSpawn;
	public float shootCooldown;
	
	public List<GameObject> enemyList = new List<GameObject>();
	
	private bool shooting = false;

	// Update is called once per frame
	void Update () {
		//Debug.Log(shooting);
		for (int i = 0; i < enemyList.Count; i++) {
			if(enemyList[i] == null){
				RemoveTarget(enemyList[i]);
			}
		}
		if(enemyList.Count > 0){
			LockOnTarget ();
		}else if(shooting) {shooting = false; Debug.Log("gdgdf");}
	}
	
	void LockOnTarget(){
		if(enemyList[0] != null){
			gun.transform.LookAt (enemyList[0].gameObject.transform.position);
			gun.transform.Rotate (new Vector3 (90, 0, 0));
			if (shooting == false) {
				shooting = true;
				Shoot();
			}else if (shooting){
				shootCooldown -= Time.deltaTime;
				if(shootCooldown <= 0){
					Shoot();
				}
			}
		}
		
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "Enemy"){
			enemyScript targetScript = target.gameObject.GetComponent<enemyScript> ();
			float targetSpeed = targetScript.speed;
			float targetHealth = targetScript.hp;

			if(enemyList.Count > 0){
				//hij kijkt of de enemy sneller is en minder leven heeft dan de ander. Anders maakt hij eerst de minder leven af anders is het minder functioneel
				if (targetSpeed > enemyList[0].GetComponent<enemyScript>().speed && targetHealth <= enemyList[0].GetComponent<enemyScript>().hp) {
					enemyList.Add(enemyList[0]);
					enemyList[0] = target.gameObject;

				}else{
					enemyList.Add(target.gameObject);	
				}
			}else{
				enemyList.Add(target.gameObject);	
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(enemyList.Count > 0){
			if (other.gameObject.tag == "Enemy") {
				RemoveTarget(other.gameObject);
			}
		}
		//enemyList.Sort ();
	}
	void Shoot(){
		shootCooldown = 0.20f;
		Instantiate (bullet,bulletSpawn.transform.position, gun.transform.rotation);
	}
	void RemoveTarget(GameObject other){
		enemyList.Remove (other);
	}
}
