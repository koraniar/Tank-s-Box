using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject pad;
	public GameObject menu;
	public GameObject spawn;
	public GameObject center;
	public SpriteRenderer player;
	public Image menuPlayer;
	public Image mus;
	public Image efx;
	public Image vib;
	public GameObject cVerde;
	public GameObject cRojo;
	public GameObject cAmarillo;
	public GameObject cGris;
	public GameObject cGrisBlue;
	public GameObject lvvl2;
	public GameObject lvvl3;
	public GameObject lvvl4;
	public GameObject lvvl5;
	public GameObject lvvl6;
	public GameObject lvvl7;
	public GameObject lvvl8;
	public GameObject lvvl9;
	public GameObject lvvl10;
	public Sprite ver;
	public Sprite roj;
	public Sprite ama;
	public Sprite gri;
	public Sprite grb;
	public Sprite vol;
	public Sprite nVol;
	public Sprite vibr;
	public Sprite nVib;
	public bool musica = true;
	public bool efectos = true;
	public bool vibrac = true;
	public int salida = 0;
	public int color = 1;
	public string texto = "Nombre";
	DataTravel dato;
	Animator anim;
	
	void Start () {
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 0;
		anim = GetComponent<Animator> ();
		dato = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
	}

	public void inic(){
		anim.Play("StartMenu");
	}
	IEnumerator Inicio() {
		yield return new WaitForSeconds(1);
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 2;
		spawn.SetActive(true);
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("camerita");
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("reorganizar");
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("inicio2");
		yield return new WaitForSeconds(1);
		center.SetActive(true);
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("music");
		pad.SetActive(true);
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("enmigos");
		GameObject.FindGameObjectWithTag("Spawn").SendMessage("cullComp");
		menu.SetActive (false);
	}

	public void play(){
		StartCoroutine(Inicio());
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
		anim.Play("PlayGame");
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("map1");
		Camera.main.transform.position = new Vector3(0f,-5.53f,-10f);
	}

	public void credit(){
		anim.Play("Creditos");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 1;
		salida = 1;
	}

	public void config(){
		anim.Play("Config");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 1;
		if (musica) {
			mus.sprite = vol;
		} else {
			mus.sprite = nVol;
		}
		if (efectos) {
			efx.sprite = vol; 
		} else {
			efx.sprite = nVol;
		}
		if (vibrac) {
			vib.sprite = vibr; 
		} else {
			vib.sprite = nVib;
		}
		salida = 2;
	}

	public void ads(){
		anim.Play("Ads");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 1;
		salida = 3;
	}

	public void store(){
		anim.Play("Store");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 1;
		colii ();
		salida = 4;
	}

	public void nivels(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		shd.scenes = 1;
		if (shd.lvl2 == 0) {
			lvvl2.SetActive(true);
		} else {
			lvvl2.SetActive(false);
		}
		if (shd.lvl3 == 0) {
			lvvl3.SetActive(true);
		} else {
			lvvl3.SetActive(false);
		}
		if (shd.lvl4 == 0) {
			lvvl4.SetActive(true);
		} else {
			lvvl4.SetActive(false);
		}
		if (shd.lvl5 == 0) {
			lvvl5.SetActive(true);
		} else {
			lvvl5.SetActive(false);
		}
		if (shd.lvl6 == 0) {
			lvvl6.SetActive(true);
		} else {
			lvvl6.SetActive(false);
		}
		if (shd.lvl7 == 0) {
			lvvl7.SetActive(true);
		} else {
			lvvl7.SetActive(false);
		}
		if (shd.lvl8 == 0) {
			lvvl8.SetActive(true);
		} else {
			lvvl8.SetActive(false);
		}
		if (shd.lvl9 == 0) {
			lvvl9.SetActive(true);
		} else {
			lvvl9.SetActive(false);
		}
		if (shd.lvl10 == 0) {
			lvvl10.SetActive(true);
		} else {
			lvvl10.SetActive(false);
		}
		anim.Play("Niveles");
		salida = 5;
	}

	public void puntuacion(){
		anim.Play("Puntua");
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 1;
		salida = 6;
	}

	public void exit(){
		DataTravel hys = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		hys.scenes = 0;
		if(salida == 1){
			anim.Play ("ExCedits");
		}else if(salida == 2){
			anim.Play ("ExConfig");
			if(musica){
				dato.sonido = 1;
			}else{
				dato.sonido = 0;
			}
			if(efectos){
				dato.efectos = 1;
			}else{
				dato.efectos = 0;
			}
			if(vibrac){
				dato.vibracion = 1;
			}else{
				dato.vibracion = 0;
			}
			GameObject.FindGameObjectWithTag("MainCamera").SendMessage("sett");
			GameObject.FindGameObjectWithTag("Player").SendMessage("efect");
		}else if(salida == 3){
			anim.Play ("ExAds");
		}else if(salida == 4){
			anim.Play ("ExStore");
			dato.colo = color;
			GameObject.FindGameObjectWithTag("MainCamera").SendMessage("col");
		}else if(salida == 5){
			anim.Play ("ExNiveles");
		}else if(salida == 6){
			anim.Play ("ExPuntua");
		}
	}

	public void level1(){
		StartCoroutine(Inicio());
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
		anim.Play("Play1");
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("map1");
	}

	public void level2(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl2 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play2");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map2");
		}
	}

	public void level3(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl3 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play3");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map3");
		}
	}

	public void level4(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl4 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play4");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map4");
		}
	}

	public void level5(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl5 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play5");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map5");
		}
	}

	public void level6(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl6 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play6");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map6");
		}
	}

	public void level7(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl7 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play7");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map7");
		}
	}

	public void level8(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl8 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play8");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map8");
		}
	}

	public void level9(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl9 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play9");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map9");
		}
	}

	public void level10(){
		DataTravel shd = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (shd.lvl10 == 0) {
		} else {
			StartCoroutine (Inicio ());
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			anim.Play ("Play10");
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("map10");
		}
	}

	public void music(){
		if (musica) {
			mus.sprite = nVol;
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("pauss");
			musica = false;
		} else {
			mus.sprite = vol;
			GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("muenusatom");
			musica = true;
		}
	}

	public void vivvr(){
		if (vibrac) {
			vib.sprite = nVib;
			vibrac = false;
		} else {
			vib.sprite = vibr;
			vibrac = true;
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
			Handheld.Vibrate();
		}
	}

	public void efecto(){
		if (efectos) {
			efx.sprite = nVol;
			efectos = false; 
		} else {
			efx.sprite = vol;
			efectos = true;
		}
	}

	public void colii(){
		if(color == 1){
			cVerde.SetActive (true);
			cRojo.SetActive (false);
			cAmarillo.SetActive (false);
			cGris.SetActive (false);
			cGrisBlue.SetActive (false);
			verde();
		}else if(color == 2){
			cVerde.SetActive (false);
			cRojo.SetActive (true);
			cAmarillo.SetActive (false);
			cGris.SetActive (false);
			cGrisBlue.SetActive (false);
			rojo();
		}else if(color == 3){
			cVerde.SetActive (false);
			cRojo.SetActive (false);
			cAmarillo.SetActive (true);
			cGris.SetActive (false);
			cGrisBlue.SetActive (false);
			amarillo();
		}else if(color == 4){
			cVerde.SetActive (false);
			cRojo.SetActive (false);
			cAmarillo.SetActive (false);
			cGris.SetActive (true);
			cGrisBlue.SetActive (false);
			gris ();
		}else if(color == 5){
			cVerde.SetActive (false);
			cRojo.SetActive (false);
			cAmarillo.SetActive (false);
			cGris.SetActive (false);
			cGrisBlue.SetActive (true);
			grisAzul();
		}
	}

	public void verde(){
		menuPlayer.sprite = ver;
		player.sprite = ver;
		cVerde.SetActive (true);
		cRojo.SetActive (false);
		cAmarillo.SetActive (false);
		cGris.SetActive (false);
		cGrisBlue.SetActive (false);
		color = 1;
	}
	public void rojo(){
		menuPlayer.sprite = roj;
		player.sprite = roj;
		cVerde.SetActive (false);
		cRojo.SetActive (true);
		cAmarillo.SetActive (false);
		cGris.SetActive (false);
		cGrisBlue.SetActive (false);
		color = 2;
	}
	public void amarillo(){
		menuPlayer.sprite = ama;
		player.sprite = ama;
		cVerde.SetActive (false);
		cRojo.SetActive (false);
		cAmarillo.SetActive (true);
		cGris.SetActive (false);
		cGrisBlue.SetActive (false);
		color = 3;
	}
	public void gris(){
		menuPlayer.sprite = gri;
		player.sprite = gri;
		cVerde.SetActive (false);
		cRojo.SetActive (false);
		cAmarillo.SetActive (false);
		cGris.SetActive (true);
		cGrisBlue.SetActive (false);
		color = 4;
	}
	public void grisAzul(){
		menuPlayer.sprite = grb;
		player.sprite = grb;
		cVerde.SetActive (false);
		cRojo.SetActive (false);
		cAmarillo.SetActive (false);
		cGris.SetActive (false);
		cGrisBlue.SetActive (true);
		color = 5;
	}
}
