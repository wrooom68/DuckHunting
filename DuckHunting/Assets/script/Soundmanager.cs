using UnityEngine;
using System.Collections;

public class Soundmanager : MonoBehaviour {

	public AudioSource bg;
	public AudioSource shot;
	public AudioSource killshot;
	public AudioSource Click;
	public AudioSource highwin;

	private static Soundmanager _instance ;

	void Awake()
	{
		//if we don't have an [_instance] set yet
		if(!_instance)
			_instance = this ;
		//otherwise, if we do, kill this thing
		else
			Destroy(this.gameObject) ;
		
		
		DontDestroyOnLoad(this.gameObject) ;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
