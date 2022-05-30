using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

	public Text highscore;

	public RawImage sound;
	public Texture sOn;
	public Texture sOff;

	// Use this for initialization
	void Start () {

		ScoreCheck ();
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().bg.Play ();
			sound.texture = sOn;
		} else {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().bg.Stop ();
			sound.texture = sOff;
		}

		StartCoroutine ("showAd");
	}

	IEnumerator showAd(){
		yield return new WaitForSeconds (0.5f);
		GameObject admob = GameObject.Find ("AdMob");
		admob.GetComponent<GoogleMobileAdScript> ().HideBanner1 ();
		admob.GetComponent<GoogleMobileAdScript> ().ShowBanner ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayClick(){
		BTclick ();
		Application.LoadLevel ("Forest");
		GameObject admob = GameObject.Find ("AdMob");
		admob.GetComponent<GoogleMobileAdScript> ().ShowInterstial ();
	}

	void ScoreCheck(){
		highscore.text = "" + PlayerPrefs.GetInt ("HIGHSCORE").ToString();
	}

	public void BTclick(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().Click.Play ();
		}
	}

	public void OnSoundClick(){
		if (PlayerPrefs.GetInt ("SOUND") == 0) {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().bg.Stop ();
			sound.texture = sOff;
			PlayerPrefs.SetInt ("SOUND", 1);
		} else {
			GameObject sounder = GameObject.Find ("SOUNDER");
			sounder.GetComponent<Soundmanager> ().bg.Play ();
			sound.texture = sOn;
			PlayerPrefs.SetInt ("SOUND", 0);
		}
		BTclick ();
	}

	public void OnQuitClick(){
		BTclick ();
		Application.Quit ();
	}

	public void OnRateUsClick(){
		BTclick ();
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.wrooom68.justhunting");
	}
}
