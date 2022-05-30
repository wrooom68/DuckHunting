using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject theBird;
	public Canvas pause;
	public Canvas gmovr;
	public static int Instancemax=15;
	public GameObject pos2;
	public GameObject pos3;
	// Use this for initialization
	void Start () {
		pause.enabled = false;
		gmovr.enabled = false;
//		GameObject sounder = GameObject.Find ("SOUNDER");
//		sounder.GetComponent<Soundmanager> ().bg.Play ();
		Birdmover.max = 3;
		InstanceBird ();
		StartCoroutine ("Birdmanage");
		Time.timeScale = 1;
		GameObject admob = GameObject.Find ("AdMob");
		admob.GetComponent<GoogleMobileAdScript> ().HideBanner ();
		admob.GetComponent<GoogleMobileAdScript> ().ShowBanner1 ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Birdmanage(){
		int temp = Random.Range (3, Instancemax);
		yield return new WaitForSeconds (temp);
		InstanceBird3 ();
		StartCoroutine ("Birdmanage");
	}

	public void InstanceBird(){
		if (Theplayer.birdKilled > 120) {
			int temp = Random.Range (0, 3);
			if (temp == 2) {
				GameObject gg = Instantiate (theBird, pos3.transform.position, pos3.transform.rotation)   as GameObject;
				Vector3 pos = gg.transform.position;
				pos.y = Random.Range (5, 15);
				pos.x = Random.Range (-20, 20);
				gg.transform.position = pos;
			} else if (temp == 1) {
				GameObject gg = Instantiate (theBird, transform.position, transform.rotation)   as GameObject;
				Vector3 pos = gg.transform.position;
				pos.y = Random.Range (5, 15);
				pos.z = Random.Range (10, 30);
				gg.transform.position = pos;
			} else {
				GameObject gg = Instantiate (theBird, pos2.transform.position, pos2.transform.rotation)   as GameObject;
				Vector3 pos = gg.transform.position;
				pos.y = Random.Range (5, 15);
				pos.z = Random.Range (10, 30);
				gg.transform.position = pos;
			}
		} else if (Theplayer.birdKilled > 60) {
			int temp = Random.Range (0, 2);
			if (temp == 1) {
				GameObject gg = Instantiate (theBird, transform.position, transform.rotation)   as GameObject;
				Vector3 pos = gg.transform.position;
				pos.y = Random.Range (5, 15);
				pos.z = Random.Range (10, 30);
				gg.transform.position = pos;
			} else {
				GameObject gg = Instantiate (theBird, pos2.transform.position, pos2.transform.rotation)   as GameObject;
				Vector3 pos = gg.transform.position;
				pos.y = Random.Range (5, 15);
				pos.z = Random.Range (10, 30);
				gg.transform.position = pos;
			}
		} else {
			GameObject gg = Instantiate (theBird, transform.position, transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.z = Random.Range (10, 30);
			gg.transform.position = pos;
		}
	}
	public void InstanceBird2(){
		int temp = Random.Range (0,10);
		if (temp % 2 == 0) {
			GameObject gg = Instantiate (theBird, transform.position, transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.z = Random.Range (10, 30);
			gg.transform.position = pos;
		} else {
			GameObject gg = Instantiate (theBird, pos2.transform.position, pos2.transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.z = Random.Range (10, 30);
			gg.transform.position = pos;
		}
	}
	public void InstanceBird3(){
		int temp = Random.Range (0,15);
		if (temp % 3 == 0) {
			GameObject gg = Instantiate (theBird, pos3.transform.position, pos3.transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.x = Random.Range (-20, 20);
			gg.transform.position = pos;
		}else if (temp % 2 == 0) {
			GameObject gg = Instantiate (theBird, transform.position, transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.z = Random.Range (10, 30);
			gg.transform.position = pos;
		}else {
			GameObject gg = Instantiate (theBird, pos2.transform.position, pos2.transform.rotation)   as GameObject;
			Vector3 pos = gg.transform.position;
			pos.y = Random.Range (5, 15);
			pos.z = Random.Range (10, 30);
			gg.transform.position = pos;
		}
	}

	public void GameOver(){
		gmovr.enabled = true;
		StopAllCoroutines ();
		StartCoroutine ("Timezero");
	}
	IEnumerator Timezero(){
		yield return new WaitForSeconds (3f);
		Time.timeScale = 0;
	}

	public void Restart(){
		BTclick ();
		Application.LoadLevel (Application.loadedLevel);
	}

	public void HomeClick(){
		BTclick ();
		Time.timeScale = 1;
		Application.LoadLevel ("Splash");
	}

	public void OnPauseClick(){
		BTclick ();
		Time.timeScale = 0;
		pause.enabled = true;
	}

	public void OnResumeClick(){
		Time.timeScale = 1;
		pause.enabled = false;
		BTclick ();
	}

	public void BTclick(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().Click.Play ();
		}
	}
}
