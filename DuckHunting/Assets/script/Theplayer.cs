using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Theplayer : MonoBehaviour {

	public GameObject bulet;
	public Transform bulpos;
	public Text killScore;
	public Text FkillScore;
	public Text saveScore;
	public Text FsaveScore;
	public Image scoreMeter;
	public static int birdKilled;
	public static int savedBird;
	public RawImage highScore;
	RaycastHit hit;
	public RawImage scope;
	bool go;
	bool soundplay;
	// Use this for initialization
	void Start () {
		birdKilled = 0;
		savedBird = 0;
		go = true;
		highScore.enabled = false;
		if(PlayerPrefs.GetInt ("SOUND") == 0){
			soundplay = true;
		}else{
			soundplay=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (go) {
			saveScore.text = "" + savedBird.ToString ();
			if (savedBird > birdKilled) {
				go=false;
				GameOver();
			}
			Physics.Raycast (bulpos.position, bulpos.forward, out hit, 100f);
			Debug.DrawRay (bulpos.position, bulpos.forward * 100f, Color.green);
			if (hit.collider.gameObject.tag == "BIRD" || hit.collider.gameObject.tag == "Wing") {
				scope.color = Color.red;
			} else {
				scope.color = Color.white;
			}
		}
	}

	public void OnBuletFire(){
		if(hit.collider.gameObject.tag == "BIRD"){
				hit.collider.gameObject.GetComponent<Birdmover>().Dieplay();
				birdKilled++;
				BirdSpeedIncrease();
				killScore.text = ""+birdKilled.ToString();
			if(soundplay){
				GameObject sounder = GameObject.Find ("SOUNDER");
				sounder.GetComponent<Soundmanager> ().killshot.Play ();
			}
		}else if(hit.collider.gameObject.tag == "Wing"){
				hit.collider.gameObject.GetComponentInParent<Birdmover>().Dieplay();
				birdKilled++;
				BirdSpeedIncrease();
				killScore.text = ""+birdKilled.ToString();
			if(soundplay){
				GameObject sounder = GameObject.Find ("SOUNDER");
				sounder.GetComponent<Soundmanager> ().killshot.Play ();
			}
		}else{
			if(soundplay){
				GameObject sounder = GameObject.Find ("SOUNDER");
				sounder.GetComponent<Soundmanager> ().shot.Play ();
			}
		}
	}

	public void OnStopClick(){
		go=false;
		GameOver();
	}

	void GameOver(){
		FkillScore.text = ""+birdKilled.ToString();
		FsaveScore.text = "" + savedBird.ToString ();
		int tt = PlayerPrefs.GetInt ("HIGHSCORE");
		if (birdKilled > tt) {
			PlayerPrefs.SetInt ("HIGHSCORE",birdKilled);
			highScore.enabled=true;
			tt=birdKilled;
			if(soundplay){
				GameObject sounder = GameObject.Find ("SOUNDER");
				sounder.GetComponent<Soundmanager> ().highwin.Play ();
			}
		}
		scoreMeter.fillAmount = (float)birdKilled / (float)tt;
		GameObject.Find ("Manager").GetComponent<Manager> ().GameOver ();
		GameObject admob = GameObject.Find ("AdMob");
		admob.GetComponent<GoogleMobileAdScript> ().ShowInterstial ();
	}

	void BirdSpeedIncrease(){
			if (birdKilled > 150) {
			Manager.Instancemax = 5;
			}else if (birdKilled > 135) {
				Birdmover.max = 8;
			} else if (birdKilled > 120) {
			Manager.Instancemax = 7;
			} else if (birdKilled > 105) {
				Birdmover.max = 7;
			} else if (birdKilled > 90) {
			Manager.Instancemax = 9;
			} else if (birdKilled > 75) {
				Birdmover.max = 6;
			} else if (birdKilled > 60) {
			Manager.Instancemax = 11;
			} else if (birdKilled > 45) {
				Birdmover.max = 5;
			} else if (birdKilled > 30) {
			Manager.Instancemax = 13;
			} else if (birdKilled > 15) {
				Birdmover.max = 4;
			}else{
				Birdmover.max = 3;
				Manager.Instancemax = 15;
			}
	}
}
