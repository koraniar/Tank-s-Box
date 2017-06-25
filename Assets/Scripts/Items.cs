using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Items : MonoBehaviour {
	public float time = 25;
	float transp;
	SpriteRenderer item;
	AudioSource mus;
	Animator itemG;

	void Start () {
		item = GetComponent<SpriteRenderer> ();
		itemG = GetComponent<Animator> ();
		mus = GetComponent<AudioSource>();
	}

	void Update () {
		time -= Time.deltaTime;
		transp = time / 25;
		item.color = new Color 	(1f, 1f, 1f, transp);
		if (time <= 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			DataTravel fexs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
			itemG.enabled = true;
			if (fexs.efectos == 1){
				mus.Play();
			}
			Destroy (gameObject, 1f);
		} else if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "BalaEnm") {
			Destroy (gameObject);
			SpawnCenter discon = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
			discon.enmMax += 2;
			discon.enmMaxRonda += 2;
			discon.enmRest += 2;
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
		} else if (other.gameObject.tag == "Bala") {
			Destroy (gameObject);
			SpawnCenter discon = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
			discon.enmMax += 3;
			discon.enmMaxRonda += 3;
			discon.enmRest += 3;
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
		}
	}
}
