using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataTravel : MonoBehaviour {

	public InputField input;
	public AudioSource hola;
	public AudioClip menu;
	public AudioClip juego;
	public AudioClip juego2;
	public bool trans = true;
	int data = 0;
	public int sonido = 1;
	public int efectos = 1;
	public int vibracion = 1;
	public int colo = 1;
	public int lvl2 = 0;
	public int lvl3 = 0;
	public int lvl4 = 0;
	public int lvl5 = 0;
	public int lvl6 = 0;
	public int lvl7 = 0;
	public int lvl8 = 0;
	public int lvl9 = 0;
	public int lvl10 = 0;
	public Text nomb1;
	public Text nomb2;
	public Text nomb3;
	public Text nomb4;
	public Text nomb5;
	public string nom1 = "Nombre";
	public string nom2 = "Nombre";
	public string nom3 = "Nombre";
	public string nom4 = "Nombre";
	public string nom5 = "Nombre";
	public Text punt1;
	public Text punt2;
	public Text punt3;
	public Text punt4;
	public Text punt5;
	public string pun1 = "0";
	public string pun2 = "0";
	public string pun3 = "0";
	public string pun4 = "0";
	public string pun5 = "0";
	public string newpun = "0";
	public string newnomb;
	public int tutorial = 0;
	public int scenes = 0;
	bool avalible = true;
	int avaldem = 1;
	float lmul;

	void Awake () {
		cargar ();
		hola.clip = menu;
		if (sonido == 0) {
			hola.Stop();
		}
	}

	void Update () {
		if( Input.GetKey( KeyCode.Escape ) )
		{
			if(avalible){
				if(scenes == 0){
					Application.Quit();
				}else if(scenes == 1){
					GameObject.FindGameObjectWithTag("Menu").SendMessage("exit");
					avaldem = 2;
				}else if(scenes == 2){
					GameObject.FindGameObjectWithTag("Spawn").SendMessage("pausing");
					avaldem = 1;
				}else if(scenes == 3){
					GameObject.FindGameObjectWithTag("Spawn").SendMessage("seguimos");
					avaldem = 1;
				}
				avalible = false;
				StartCoroutine(dispon());
			}
		}
	}

	IEnumerator dispon (){
		yield return new WaitForSeconds(avaldem);
		avalible = true;
	}

	public void cargar(){
		if(PlayerPrefs.HasKey("tutorial")){
			tutorial = PlayerPrefs.GetInt("tutorial");
		}
		if(PlayerPrefs.HasKey("color")){
			colo = PlayerPrefs.GetInt("color");
		}
		if(PlayerPrefs.HasKey("music")){
			sonido = PlayerPrefs.GetInt("music");
		}
		if(PlayerPrefs.HasKey("efect")){
			efectos = PlayerPrefs.GetInt("efect");
		}
		if(PlayerPrefs.HasKey("vibrans")){
			vibracion = PlayerPrefs.GetInt("vibrans");
		}
		Menu men = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
		men.color = colo;
		GameObject.FindGameObjectWithTag ("Menu").SendMessage ("colii");
		if(PlayerPrefs.HasKey("nom1")){
			nom1 = PlayerPrefs.GetString("nom1");
		}
		if(PlayerPrefs.HasKey("nom2")){
			nom2 = PlayerPrefs.GetString("nom2");
		}
		if(PlayerPrefs.HasKey("nom3")){
			nom3 = PlayerPrefs.GetString("nom3");
		}
		if(PlayerPrefs.HasKey("nom4")){
			nom4 = PlayerPrefs.GetString("nom4");
		}
		if(PlayerPrefs.HasKey("nom5")){
			nom5 = PlayerPrefs.GetString("nom5");
		}
		if(PlayerPrefs.HasKey("pun1")){
			pun1 = PlayerPrefs.GetString("pun1");
		}
		if(PlayerPrefs.HasKey("pun2")){
			pun2 = PlayerPrefs.GetString("pun2");
		}
		if(PlayerPrefs.HasKey("pun3")){
			pun3 = PlayerPrefs.GetString("pun3");
		}
		if(PlayerPrefs.HasKey("pun4")){
			pun4 = PlayerPrefs.GetString("pun4");
		}
		if(PlayerPrefs.HasKey("pun5")){
			pun5 = PlayerPrefs.GetString("pun5");
		}
		if(PlayerPrefs.HasKey("lvl2")){
			lvl2 = PlayerPrefs.GetInt("lvl2");
		}
		if(PlayerPrefs.HasKey("lvl3")){
			lvl3 = PlayerPrefs.GetInt("lvl3");
		}
		if(PlayerPrefs.HasKey("lvl4")){
			lvl4 = PlayerPrefs.GetInt("lvl4");
		}
		if(PlayerPrefs.HasKey("lvl5")){
			lvl5 = PlayerPrefs.GetInt("lvl5");
		}
		if(PlayerPrefs.HasKey("lvl6")){
			lvl6 = PlayerPrefs.GetInt("lvl6");
		}
		if(PlayerPrefs.HasKey("lvl7")){
			lvl7 = PlayerPrefs.GetInt("lvl7");
		}
		if(PlayerPrefs.HasKey("lvl8")){
			lvl8 = PlayerPrefs.GetInt("lvl8");
		}
		if(PlayerPrefs.HasKey("lvl9")){
			lvl9 = PlayerPrefs.GetInt("lvl9");
		}
		if(PlayerPrefs.HasKey("lvl10")){
			lvl10 = PlayerPrefs.GetInt("lvl10");
		}
		punt1.text = pun1;
		punt2.text = pun2;
		punt3.text = pun3;
		punt4.text = pun4;
		punt5.text = pun5;
		nomb1.text = nom1;
		nomb2.text = nom2;
		nomb3.text = nom3;
		nomb4.text = nom4;
		nomb5.text = nom5;
		if (sonido == 1) {
			men.musica = true;
		} else {
			men.musica = false;
		}
		if (efectos == 1) {
			men.efectos = true;
		} else {
			men.efectos = false;
		}
		if (vibracion == 1) {
			men.vibrac = true;
		} else {
			men.vibrac = false;
		}
		GameObject.FindGameObjectWithTag ("Player").SendMessage ("actial");
		if (data == 0) {
			if (tutorial == 0) {
				Application.LoadLevel ("Tutorial");
			}
		}
	}

	public void guardarPun(){
		newnomb = input.text;
		Respawn pin = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
		newpun = pin.puntaje.ToString();
		int val1 = int.Parse (pun1);
		int val2 = int.Parse (pun2);
		int val3 = int.Parse (pun3);
		int val4 = int.Parse (pun4);
		int val5 = int.Parse (pun5);
		int valo = int.Parse (newpun);
		if (valo >= val1) {
			nom5 = nom4;
			pun5 = pun4;
			nom4 = nom3;
			pun4 = pun3;
			nom3 = nom2;
			pun3 = pun2;
			nom2 = nom1;
			pun2 = pun1;
			nom1 = newnomb;
			pun1 = newpun;
		}else if(valo >= val2){
			nom5 = nom4;
			pun5 = pun4;
			nom4 = nom3;
			pun4 = pun3;
			nom3 = nom2;
			pun3 = pun2;
			nom2 = newnomb;
			pun2 = newpun;
		}else if(valo >= val3){
			nom5 = nom4;
			pun5 = pun4;
			nom4 = nom3;
			pun4 = pun3;
			nom3 = newnomb;
			pun3 = newpun;
		}else if(valo >= val4){
			nom5 = nom4;
			pun5 = pun4;
			nom4 = newnomb;
			pun4 = newpun;
		}else if(valo >= val5){
			nom5 = newnomb;
			pun5 = newpun;
		}
		punt1.text = pun1;
		punt2.text = pun2;
		punt3.text = pun3;
		punt4.text = pun4;
		punt5.text = pun5;
		nomb1.text = nom1;
		nomb2.text = nom2;
		nomb3.text = nom3;
		nomb4.text = nom4;
		nomb5.text = nom5;
		PlayerPrefs.SetString ("nom1",nom1);
		PlayerPrefs.SetString ("nom2",nom2);
		PlayerPrefs.SetString ("nom3",nom3);
		PlayerPrefs.SetString ("nom4",nom4);
		PlayerPrefs.SetString ("nom5",nom5);
		PlayerPrefs.SetString ("pun1",pun1);
		PlayerPrefs.SetString ("pun2",pun2);
		PlayerPrefs.SetString ("pun3",pun3);
		PlayerPrefs.SetString ("pun4",pun4);
		PlayerPrefs.SetString ("pun5",pun5);
		GameObject.FindGameObjectWithTag ("Player").SendMessage ("actial");
	}

	public void col(){
		PlayerPrefs.SetInt ("color",colo);
	}

	public void sett(){
		PlayerPrefs.SetInt ("music",sonido);
		PlayerPrefs.SetInt ("efect",efectos);
		PlayerPrefs.SetInt ("vibrans",vibracion);
	}

	public void reset(){
		pun1 = "0";
		pun2 = "0";
		pun3 = "0";
		pun4 = "0";
		pun5 = "0";
		nom1 = "Nombre";
		nom2 = "Nombre";
		nom3 = "Nombre";
		nom4 = "Nombre";
		nom5 = "Nombre";
		tutorial = 0;
		sonido = 1;
		efectos = 1;
		vibracion = 1;
		colo = 1;
		lvl2 = 0;
		lvl3 = 0;
		lvl4 = 0;
		lvl5 = 0;
		lvl6 = 0;
		lvl7 = 0;
		lvl8 = 0;
		lvl9 = 0;
		lvl10 = 0;
		PlayerPrefs.SetInt ("color",colo);
		PlayerPrefs.SetInt ("music",sonido);
		PlayerPrefs.SetInt ("efect",efectos);
		PlayerPrefs.SetInt ("vibrans",vibracion);
		PlayerPrefs.SetInt ("tutorial",tutorial);
		PlayerPrefs.SetInt ("lvl2",lvl2);
		PlayerPrefs.SetInt ("lvl3",lvl3);
		PlayerPrefs.SetInt ("lvl4",lvl4);
		PlayerPrefs.SetInt ("lvl5",lvl5);
		PlayerPrefs.SetInt ("lvl6",lvl6);
		PlayerPrefs.SetInt ("lvl7",lvl7);
		PlayerPrefs.SetInt ("lvl8",lvl8);
		PlayerPrefs.SetInt ("lvl9",lvl9);
		PlayerPrefs.SetInt ("lvl10",lvl10);
		PlayerPrefs.SetString ("nom1",nom1);
		PlayerPrefs.SetString ("nom2",nom2);
		PlayerPrefs.SetString ("nom3",nom3);
		PlayerPrefs.SetString ("nom4",nom4);
		PlayerPrefs.SetString ("nom5",nom5);
		PlayerPrefs.SetString ("pun1",pun1);
		PlayerPrefs.SetString ("pun2",pun2);
		PlayerPrefs.SetString ("pun3",pun3);
		PlayerPrefs.SetString ("pun4",pun4);
		PlayerPrefs.SetString ("pun5",pun5);
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
		data = 1;
		GameObject.FindGameObjectWithTag ("MainCamera").SendMessage ("muenusatom");
		cargar ();
		GameObject.FindGameObjectWithTag ("Menu").SendMessage ("exit");
	}

	public void levels(){
		PlayerPrefs.SetInt ("lvl2",lvl2);
		PlayerPrefs.SetInt ("lvl3",lvl3);
		PlayerPrefs.SetInt ("lvl4",lvl4);
		PlayerPrefs.SetInt ("lvl5",lvl5);
		PlayerPrefs.SetInt ("lvl6",lvl6);
		PlayerPrefs.SetInt ("lvl7",lvl7);
		PlayerPrefs.SetInt ("lvl8",lvl8);
		PlayerPrefs.SetInt ("lvl9",lvl9);
		PlayerPrefs.SetInt ("lvl10",lvl10);
	}

	public void muenuss(){
		if (sonido == 1) {
			hola.clip = menu;
			hola.Play ();
		}
	}

	public void muenusatom(){
		hola.clip = menu;
		hola.Play ();
	}

	public void music(){
		if (sonido == 1) {
			lmul = Random.Range (1.0f, 10.0f);
			if (lmul < 2f || lmul > 3f && lmul < 4f || lmul > 5f && lmul < 6f || lmul > 7f && lmul < 8f || lmul > 9f && lmul < 10f) {
				hola.clip = juego;
				hola.Play ();
				trans = false;
			} else {
				hola.clip = juego2;
				hola.Play ();
				trans = true;
			}
		}
	}

	public void pauss(){
		hola.Stop ();
	}

	public void seg(){
		if (sonido == 1) {
			hola.Play ();
		}
	}

	public void tutt(){
		PlayerPrefs.SetInt ("tutorial",tutorial);
	}
}
