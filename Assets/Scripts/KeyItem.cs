using UnityEngine;
using System.Collections;

public class KeyItem : MonoBehaviour {


	Animator keylam;
	AudioSource mus;

	void Start () {
		keylam = GetComponent<Animator>();
		mus = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			keylam.enabled = true;
			DataTravel fexs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
			if (fexs.efectos == 1){
				mus.Play();
			}
			DoorExit exit = GameObject.FindGameObjectWithTag("door").GetComponent<DoorExit>();
			exit.key = true;
			Destroy (gameObject, 1f);
		} else if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "BalaEnm") {
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("avalible");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("avalible");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("keyRespa");
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Bala") {
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("avalible");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("avalible");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("avalible");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("keyRespa");
			Destroy (gameObject);
		}
	}
}
