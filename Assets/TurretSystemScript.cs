﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretSystemScript : MonoBehaviour {
	
	public GameObject gun;
	public GameObject bullet;
	
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
		}else{shooting = false;}
	}
	
	void LockOnTarget(){
		if(enemyList[0] != null){
			gun.transform.LookAt (enemyList[0].gameObject.transform.position);
			gun.transform.Rotate (new Vector3 (90, 0, 0));
			if (shooting == false && enemyList.Count > 0) {
				shooting = true;
				Shoot();
			}
		}
		
	}
	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag == "Enemy"){
			float targetSpeed = target.gameObject.GetComponent<enemyScript> ().speed;
			float targetHealth = target.gameObject.GetComponent<enemyScript>().hp;

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
		if(shooting){
			Invoke("Shoot",0.25f);
		}
		if(enemyList.Count > 0){
			Instantiate (bullet,gun.transform.position, gun.transform.rotation);
		}
	}
	void RemoveTarget(GameObject other){
		enemyList.Remove (other);
	}
}
