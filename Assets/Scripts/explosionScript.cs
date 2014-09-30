using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 0.4f);
	}
}
