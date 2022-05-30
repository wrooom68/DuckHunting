using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using CnControls;

public class Joyrotation : MonoBehaviour {

	public GameObject stick;
	float xpos;
	bool Rotate;

	// Use this for initialization
	void Start () {
		Rotate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Rotate) {
			xpos = stick.transform.position.x;
			Quaternion eulerRot = Quaternion.Euler (0.0f, xpos, 0.0f);
			transform.rotation = Quaternion.Slerp (transform.rotation, eulerRot, Time.deltaTime * 10);
		}
	}

	public void OnjoyDown(){
		Rotate = true;
	}
	public void OnjoyUp(){
		Rotate = false;
	}
}
