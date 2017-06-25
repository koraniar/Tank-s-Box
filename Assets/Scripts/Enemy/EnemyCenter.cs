using UnityEngine;
using System.Collections;

public class EnemyCenter : MonoBehaviour {

	public int balas = 0;
	int g = 0;
	public GameObject[] enemigos;

	void Update () {
		enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
	}

	public void Asignar(){
		if (balas > enemigos.Length) {
			balas = 1;
		}
		g = balas - 1;
		MovEnemigo cont = enemigos[g].GetComponent<MovEnemigo> ();
		cont.dispMax += 1;
	}

	public void comprobar(){
		if (enemigos.Length == 1) {
			balas = 1;
			Asignar();
		} else if (enemigos.Length == 2) {
			balas = 2;
			Asignar();
		} else if (enemigos.Length == 3) {
			balas = 3;
			Asignar();
		}
	}

	public void Destro(){
		for (int a=0; a < enemigos.Length; a++){
			Destroy(enemigos[a]);
		}
	}
}