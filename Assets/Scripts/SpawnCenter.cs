using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnCenter : MonoBehaviour {
	public Transform Spawn1;
	public Transform Spawn3;
	public Transform Spawn4;
	public Transform Spawn5;
	public Transform playerSpawn;
	public Transform keySpawn;
	public GameObject keylam;
	public GameObject enemy;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	public GameObject enemy6;
	public Animator canvas;
	public Text enemigos;
	public int enmFin = 20;
	public int enmMax = 4;
	public int enmMaxRonda = 10;
	public int enmRest;
	GameObject resultado;
	int enemyvivos;
	Mapa mappp;
	int mapaend;
	
	void Start () {
		canvas.cullingMode = AnimatorCullingMode.CullCompletely;
	}

	public void reSpawnMap(){
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("levelAct");
		StartCoroutine(nextlevel());
	}

	IEnumerator nextlevel() {
		Mapa niw = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mapa>();
		if (niw.mapp == 11) {
			yield return new WaitForSeconds (4);
			canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
			canvas.Play("CanNomb");
		} else {
			yield return new WaitForSeconds (1);
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("destruMa");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("next");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("camerita");
			reorganizar ();
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("inicio2");
			yield return new WaitForSeconds (2);
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("music");
			canvas.Play ("CanEnter");
			enmigos ();
			yield return new WaitForSeconds (1);
			canvas.cullingMode = AnimatorCullingMode.CullCompletely;
			GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Corazones");
		}
	}

	public void enmigos(){
		mappp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mapa>();
		if(mappp.mapp == 1){
			enmFin = 20;
			enmMax = 4;
			enmMaxRonda = 10;
		}else if(mappp.mapp == 2){
			enmFin = 20;
			enmMax = 4;
			enmMaxRonda = 10;
		}else if(mappp.mapp == 3){
			enmFin = 22;
			enmMax = 4;
			enmMaxRonda = 10;
		}else if(mappp.mapp == 4){
			enmFin = 22;
			enmMax = 4;
			enmMaxRonda = 10;
		}else if(mappp.mapp == 5){
			enmFin = 24;
			enmMax = 4;
			enmMaxRonda = 10;
		}else if(mappp.mapp == 6){
			enmFin = 26;
			enmMax = 4;
			enmMaxRonda = 13;
		}else if(mappp.mapp == 7){
			enmFin = 28;
			enmMax = 4;
			enmMaxRonda = 15;
		}else if(mappp.mapp == 8){
			enmFin = 30;
			enmMax = 5;
			enmMaxRonda = 16;
		}else if(mappp.mapp == 9){
			enmFin = 36;
			enmMax = 6;
			enmMaxRonda = 18;
		}else if(mappp.mapp == 10){
			enmFin = 38;
			enmMax = 6;
			enmMaxRonda = 20;
		}
		mapaend = mappp.mapp;
		Instantiate (keylam, new Vector3 (keySpawn.position.x, keySpawn.position.y, 1f), Quaternion.identity);
		inicio ();
	}

	public void inicio(){
		mappp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mapa>();
		if (mappp.mapp == 1 || mappp.mapp == 2 || mappp.mapp == 3 || mappp.mapp == 4) {
			Instantiate (enemy, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			Instantiate (enemy2, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			Instantiate (enemy, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			Instantiate (enemy, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			enmRest = enmMaxRonda;
			EnmRest ();
			enmFin -= 4;
			enmMax -= 4;
			enmMaxRonda -= 4;
		} else if (mappp.mapp == 5 || mappp.mapp == 6 || mappp.mapp == 7) {
			Instantiate (enemy3, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			Instantiate (enemy2, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			Instantiate (enemy3, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			Instantiate (enemy4, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			enmRest = enmMaxRonda;
			EnmRest ();
			enmFin -= 4;
			enmMax -= 4;
			enmMaxRonda -= 4;
		} else if (mappp.mapp == 8) {
			Instantiate (enemy5, new Vector3 (Spawn5.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			Instantiate (enemy6, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn1.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			Instantiate (enemy4, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			enmRest = enmMaxRonda;
			EnmRest ();
			enmFin -= 5;
			enmMax -= 5;
			enmMaxRonda -= 5;
		} else if (mappp.mapp == 9) {
			Instantiate (enemy5, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			Instantiate (enemy6, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			Instantiate (enemy4, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn3.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			enmRest = enmMaxRonda;
			EnmRest ();
			enmFin -= 6;
			enmMax -= 6;
			enmMaxRonda -= 6;
		} else if (mappp.mapp == 10) {
			Instantiate (enemy5, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			Instantiate (enemy6, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			Instantiate (enemy6, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			Instantiate (enemy5, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			Instantiate (enemy6, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			enmRest = enmMaxRonda;
			EnmRest ();
			enmFin -= 6;
			enmMax -= 6;
			enmMaxRonda -= 6;
		}
	}
	public void EnmRest(){
		enemigos.text = "x "+enmRest.ToString();
	}

	public void Spawn(){
		if(enmMax > 0 && enmMaxRonda > 0 && enmFin > 0){
			float spawn = Random.Range (1.0f, 6.0f);
			if(spawn <= 2.555f){
				if (mapaend == 1 || mapaend == 2 || mapaend == 3 || mapaend == 4) {
					resultado = enemy2;
				} else if (mapaend == 5 || mapaend == 6 || mapaend == 7) {
					resultado = enemy4;
				} else if (mapaend == 8 || mapaend == 9 || mapaend == 10) {
					resultado = enemy5;
				}
			}else{
				if (mapaend == 1 || mapaend == 2 || mapaend == 3 || mapaend == 4) {
					resultado = enemy;
				} else if (mapaend == 5 || mapaend == 6 || mapaend == 7) {
					resultado = enemy3;
				} else if (mapaend == 8 || mapaend == 9 || mapaend == 10) {
					resultado = enemy6;
				}
			}
			enmFin -= 1;
			enmMax -= 1;
			enmMaxRonda -= 1;
			if (spawn >= 1.0f && spawn <= 1.999f) {
				Instantiate (resultado, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
			} else if (spawn >= 2.0f && spawn <= 2.999f) {
				Instantiate (resultado, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			} else if (spawn >= 3.0f && spawn <= 3.999f) {
				Instantiate (resultado, new Vector3 (Spawn3.transform.position.x, Spawn3.transform.position.y, 0), Spawn3.transform.rotation);
			} else if (spawn >= 4.0f && spawn <= 4.999f) {
				Instantiate (resultado, new Vector3 (Spawn4.transform.position.x, Spawn4.transform.position.y, 0), Spawn4.transform.rotation);
			} else if (spawn >= 5.0f && spawn <= 6.999f) {
				Instantiate (resultado, new Vector3 (Spawn5.transform.position.x, Spawn5.transform.position.y, 0), Spawn5.transform.rotation);
			} else {
				Instantiate (resultado, new Vector3 (Spawn1.transform.position.x, Spawn1.transform.position.y, 0), Spawn1.transform.rotation);
				Debug.Log("Fuera de Rango Spawn!!!!");
			}
		}
		EnmRest();
	}

	public void reorganizar(){
		mappp = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mapa>();
		if(mappp.mapp == 1){//mapa 9
			Spawn1.position = new Vector3(-0.325f,-3.55f,0f);
			Spawn3.position = new Vector3(9.02f,2.67f,0f);
			Spawn4.position = new Vector3(2.79f,-9.78f,0f);
			Spawn5.position = new Vector3(12.13f,-3.55f,0f);
			playerSpawn.position = new Vector3(-8.11f,-5.11f,0f);
			keySpawn.position = new Vector3(13.68f,1.12f,1f);
		}else if(mappp.mapp == 2){//mapa 2
			Spawn1.position = new Vector3(5.905f,4.22f,0f);
			Spawn3.position = new Vector3(16.8f,-1.99f,0f);
			Spawn4.position = new Vector3(-3.44f,-6.67f,0f);
			Spawn5.position = new Vector3(12.13f,-9.78f,0f);
			playerSpawn.position = new Vector3(-8.11f,4.22f,0f);
			keySpawn.position = new Vector3(-8.11f,-3.55f,1f);
		}else if(mappp.mapp == 3){//Mapa 10
			Spawn1.position = new Vector3(-6.553f,-8.22f,0f);
			Spawn3.position = new Vector3(-3.44f,-3.55f,0f);
			Spawn4.position = new Vector3(2.79f,-0.44f,0f);
			Spawn5.position = new Vector3(7.46f,2.67f,0f);
			playerSpawn.position = new Vector3(16.8f,-5.11f,0f);
			keySpawn.position = new Vector3(15.24f,-8.22f,1f);
		}else if(mappp.mapp == 4){//mapa 3
			Spawn1.position = new Vector3(-8.11f,4.22f,0f);
			Spawn3.position = new Vector3(12.13f,4.22f,0f);
			Spawn4.position = new Vector3(-8.11f,-3.55f,0f);
			Spawn5.position = new Vector3(7.46f,-9.78f,0f);
			playerSpawn.position = new Vector3(16.795f,-3.55f,0f);
			keySpawn.position = new Vector3(1.23f,1.12f,1f);
		}else if(mappp.mapp == 5){//mapa 6 espacio 5 
			Spawn1.position = new Vector3(-1.88f,1.12f,0f);
			Spawn3.position = new Vector3(16.8f,-1.99f,0f);
			Spawn4.position = new Vector3(-5f,-9.78f,0f);
			Spawn5.position = new Vector3(5.91f,-5.11f,0f);
			playerSpawn.position = new Vector3(-8.11f,4.22f,0f);
			keySpawn.position = new Vector3(16.8f,-9.78f,1f);
		}else if(mappp.mapp == 6){//Mapa 7
			Spawn1.position = new Vector3(-6.55f,1.12f,0f);
			Spawn3.position = new Vector3(15.24f,-0.44f,0f);
			Spawn4.position = new Vector3(-3.44f,-8.22f,0f);
			Spawn5.position = new Vector3(10.575f,-6.67f,0f);
			playerSpawn.position = new Vector3(-0.325f,4.22f,0f);
			keySpawn.position = new Vector3(13.684f,-9.78f,1f);
		}else if(mappp.mapp == 7){//mapa 4
			Spawn1.position = new Vector3(-0.32f,2.67f,0f);
			Spawn3.position = new Vector3(16.795f,4.22f,0f);
			Spawn4.position = new Vector3(7.46f,-5.11f,0f);
			Spawn5.position = new Vector3(15.24f,-8.22f,0f);
			playerSpawn.position = new Vector3(-1.88f,-3.55f,0f);
			keySpawn.position = new Vector3(-3.44f,-8.22f,1f);
		}else if(mappp.mapp == 8){//mapa 8
			Spawn1.position = new Vector3(-5f,-3.55f,0f);
			Spawn3.position = new Vector3(7.46f,-0.44f,0f);
			Spawn4.position = new Vector3(1.23f,-8.22f,0f);
			Spawn5.position = new Vector3(13.684f,-9.78f,0f);
			playerSpawn.position = new Vector3(16.8f,4.22f,0f);
			keySpawn.position = new Vector3(-8.11f,-3.55f,1f);
		}else if(mappp.mapp == 9){//mapa 9
			Spawn1.position = new Vector3(2.79f,2.67f,0f);
			Spawn3.position = new Vector3(16.8f,4.22f,0f);
			Spawn4.position = new Vector3(10.575f,-0.44f,0f);
			Spawn5.position = new Vector3(13.68f,-6.67f,0f);
			playerSpawn.position = new Vector3(-5f,-9.78f,0f);
			keySpawn.position = new Vector3(16.8f,-9.78f,1f);
		}else if(mappp.mapp == 10){//mapa 5
			Spawn1.position = new Vector3(-1.88f,1.12f,0f);
			Spawn3.position = new Vector3(16.795f,4.22f,0f);
			Spawn4.position = new Vector3(-5f,-9.78f,0f);
			Spawn5.position = new Vector3(5.91f,-8.22f,0f);
			playerSpawn.position = new Vector3(5.91f,-1.99f,0f);
			keySpawn.position = new Vector3(-8.11f,-5.11f,1f);
		}
	}

	public void cullComp(){
		StartCoroutine(corte());
	}

	public IEnumerator corte() {
		yield return new WaitForSeconds (1);
		canvas.cullingMode = AnimatorCullingMode.CullCompletely;
	}

	public void keyRespa(){
		StartCoroutine (kre ());
	}

	public IEnumerator kre(){
		yield return new WaitForSeconds (10);
		Instantiate (keylam, new Vector3 (keySpawn.position.x, keySpawn.position.y, 1f), Quaternion.identity);
	}

	public void avalible(){
		if (enmFin > 0) {
			enmMax += 1;
			enmMaxRonda += 1;
			enmRest += 1;
			Spawn();
		}
	}
}
