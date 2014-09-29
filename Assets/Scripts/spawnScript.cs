using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject fastEnemy;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", 2f);
	}
	
	void SpawnEnemy(){
		Instantiate (fastEnemy, new Vector2 (6, -2 ), this.transform.rotation);
		Instantiate (fastEnemy, new Vector2 (8, -2 ), this.transform.rotation);
		Instantiate(enemy,new Vector2(4,2),this.transform.rotation);
		Invoke ("SpawnEnemy", 2f);
	}
}
