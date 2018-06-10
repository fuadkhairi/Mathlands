using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager instance;

	//public int Score;
	public int EXP;
	public int Level;
	//public string Name;

	public Text Scoretxt;
	public Text EXPtxt;
	public Text Nametxt;
	// Use this for initialization
	void Start () {
		instance = this;
		EXP = PlayerPrefs.GetInt ("EXP", 0);
		Nametxt.text = PlayerPrefs.GetString ("Name", "Airi");
		EXPtxt.text = ""+EXP + " -- Level " + PlayerPrefs.GetInt ("Level");
		Scoretxt.text = ""+PlayerPrefs.GetInt ("Score", 0);
		Level = PlayerPrefs.GetInt ("Level", 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (EXP >= 50) {
			Level += 1;
			EXP = 0;
			PlayerPrefs.SetInt ("EXP", EXP);
			PlayerPrefs.SetInt ("Level", Level);
			Reupdate ();
		} 
	}

	void Reupdate () {
		EXPtxt.text = ""+EXP+ " -- Level " + PlayerPrefs.GetInt ("Level");
	}
}
