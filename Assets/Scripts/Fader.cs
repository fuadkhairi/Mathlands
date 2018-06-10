using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {
	public static Fader instance;
	public Animator anim;
	public string SceneName;
	// Use this for initialization
	void Start () {
		instance = this;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame () {
		anim.SetTrigger ("Next");	
	}

	public void LoadScene () {
		UnityEngine.SceneManagement.SceneManager.LoadScene (SceneName);
	}
}
