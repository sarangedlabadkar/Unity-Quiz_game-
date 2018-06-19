using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {


	// Use this for initialization
	public AudioSource _source;
	private static bool isCreated=false;
	void Start () {
		if (!isCreated) {
			_source.Play ();
			DontDestroyOnLoad (this.gameObject);
			isCreated = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
