using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	
	public GameObject can;
	public GameObject manu;
	public GameObject enem;
	public GameObject sps;
	public GameObject fondo;
	public GameObject fondo2;
	public GameObject pausa;
	public GameObject seguir;
	public GameObject casa;
	public GameObject joyst;
	public GameObject buttn;
	public GameObject pausee;
	public Animator canvas;
	int secon;

	public void pausing(){
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 3;
		Time.timeScale = 0.0f;
		joyst.SetActive (false);
		buttn.SetActive (false);
		pausee.SetActive (false);
		fondo.SetActive (true);
		fondo2.SetActive (true);
		pausa.SetActive (true);
		seguir.SetActive (true);
		casa.SetActive (true);
	}

	public void seguimos(){
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("seg");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 2;
		Time.timeScale = 1.0f;
		fondo.SetActive (false);
		fondo2.SetActive (false);
		pausa.SetActive (false);
		seguir.SetActive (false);
		casa.SetActive (false);
		joyst.SetActive (true);
		buttn.SetActive (true);
		pausee.SetActive (true);
	}

	public void Rest(){
		Time.timeScale = 1.0f;
		fondo.SetActive (false);
		fondo2.SetActive (false);
		pausa.SetActive (false);
		seguir.SetActive (false);
		casa.SetActive (false);
		joyst.SetActive (true);
		buttn.SetActive (true);
		pausee.SetActive (true);
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 0;
		GameObject.FindGameObjectWithTag ("Player").SendMessage ("kinem");
		GameObject.FindGameObjectWithTag ("EnemCenter").SendMessage ("Destro");
		PlayerControler vivv = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControler> ();
		vivv.vivo = true;
		vivv.MovementSpeed = 0.05f;
		SpawnCenter uno = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
		uno.enmMaxRonda = 10;
		uno.enmMax = 4;
		Respawn dos = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Respawn> ();
		dos.vidas = 3;
		dos.puntaje = 0;
		HealtItem h = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealtItem> ();
		h.vi = true;
		h.shield = false;
		h.vida = 100;
		h.balDis = 0.5f;
		h.dispMax = 1;
		can.SetActive (false);
		manu.SetActive (true);
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("muenuss");
		enem.SetActive (false);
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("destruMa");
		GameObject.FindGameObjectWithTag("Menu").SendMessage("inic");
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("inicio2");
		sps.SetActive (false);
		GameObject.FindGameObjectWithTag ("BalaEnm").SendMessage ("destro");
	}

	public void sali(){
		canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		canvas.Play("ExCanNom");
		secon = 2;
		StartCoroutine (reini ());
	}

	public void perdi(){
		canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		canvas.Play("ExFin");
		secon = 3;
		StartCoroutine (reini ());
	}
	
	IEnumerator reini() {
		yield return new WaitForSeconds(secon);
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 0;
		GameObject.FindGameObjectWithTag ("Player").SendMessage ("kinem");
		GameObject.FindGameObjectWithTag ("EnemCenter").SendMessage ("Destro");
		PlayerControler vivv = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControler> ();
		vivv.vivo = true;
		vivv.MovementSpeed = 0.05f;
		SpawnCenter uno = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
		uno.enmMaxRonda = 10;
		uno.enmMax = 4;
		Respawn dos = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Respawn> ();
		dos.vidas = 3;
		dos.puntaje = 0;
		HealtItem h = GameObject.FindGameObjectWithTag ("Player").GetComponent<HealtItem> ();
		h.vi = true;
		h.shield = false;
		h.vida = 100;
		h.balDis = 0.5f;
		h.dispMax = 1;
		can.SetActive (false);
		manu.SetActive (true);
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("muenuss");
		enem.SetActive (false);
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("destruMa");
		GameObject.FindGameObjectWithTag("Menu").SendMessage("inic");
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("inicio2");
		sps.SetActive (false);
		GameObject.FindGameObjectWithTag ("BalaEnm").SendMessage ("destro");
	}
}
