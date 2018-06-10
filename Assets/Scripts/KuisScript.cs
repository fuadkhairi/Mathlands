using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuisScript : MonoBehaviour {
	public Text pertanyaan, benar, salah1, salah2, salah3;
	public string pertanyaant, benart, salah1t, salah2t, salah3t;

	public int Score;
	public int EXP;

	public AudioSource Win;
	public AudioSource Lose;

 	// Use this for initialization
	void Start () {
		PertanyaanBaru ();

		Score = PlayerPrefs.GetInt ("Score", 0);
		EXP = PlayerPrefs.GetInt ("EXP", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void JawabBenar () {
		Debug.Log ("Jawaban Benar");
		Win.Play ();
		EXP += 10;
		Score += 25;
		PlayerPrefs.SetInt ("EXP", EXP);
		PlayerPrefs.SetInt ("Score", Score);
		StartCoroutine (BackTOMaps());
	}

	public void JawabSalah () {
		Lose.Play ();
		Debug.Log ("Jawaban Salah");
		EXP += 5;
		Score -= 20;
		PlayerPrefs.SetInt ("EXP", EXP);
		PlayerPrefs.SetInt ("Score", Score);
		StartCoroutine (BackTOMaps());
	}

	public void PertanyaanBaru () {
		pertanyaan.text = pertanyaant;
		benar.text = benart;
		salah1.text = salah1t;
		salah2.text = salah2t;
		salah3.text = salah3t;
	}

	IEnumerator BackTOMaps (){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Maps");
	}
}
