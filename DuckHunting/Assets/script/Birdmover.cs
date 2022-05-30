using UnityEngine;
using System.Collections;

public class Birdmover : MonoBehaviour {

	public float birdspeed;
	public static float max;
	public AudioClip birdFall;
	public AudioClip birdKill;

	// Use this for initialization
	void Start () {
		birdspeed = Random.Range(max-2 , max);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (pos.x < -70) {
			Theplayer.savedBird++;
			Destroy(gameObject);
		}else if (pos.x > 70) {
			Theplayer.savedBird++;
			Destroy(gameObject);
		}else if (pos.z < -20) {
			Theplayer.savedBird++;
			Destroy(gameObject);
		}else {
			transform.Translate (-transform.forward * Time.deltaTime * birdspeed);
		}
	}

	public void Dieplay(){
		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<Rigidbody> ().useGravity = true;
		GetComponent<Animation> () ["fly"].speed = 5.0f;
		gameObject.tag = "Died";
		AudioSource.PlayClipAtPoint(birdKill, transform.position);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Ground") {
			if(gameObject.tag == "Died"){
				AudioSource.PlayClipAtPoint(birdFall, transform.position);
				Destroy (gameObject);
			}
		}
	}
}
