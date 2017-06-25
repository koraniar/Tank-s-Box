using UnityEngine;
using System.Collections;

public class DoorExit : MonoBehaviour {
	public bool key = false;
	public bool tutorial = false;
	public Animator canvas;

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			if (key){
				if(!tutorial){
					EnemyCenter fin = GameObject.FindGameObjectWithTag("EnemCenter").GetComponent<EnemyCenter>();
					if(fin.enemigos.Length <= 0){
						canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Animator>();
						canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
						GameObject.FindGameObjectWithTag("MainCamera").SendMessage("pauss");
						canvas.Play("NewLevel");
						GameObject.FindGameObjectWithTag("Spawn").SendMessage("reSpawnMap");
					}
				}else{
					DataTravel tet = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
					tet.tutorial = 1;
					GameObject.FindGameObjectWithTag("MainCamera").SendMessage("tutt");
					Application.LoadLevel("Game");
				}
			}
		}
	}
}
