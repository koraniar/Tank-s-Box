using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public int tutorial = 0;
	public GameObject fonmen;
	public GameObject benvenid;
	public GameObject button;
	public GameObject button1;
	public GameObject dialofgt;
	public GameObject dialg;
	public GameObject joystick;
	public GameObject dispr;
	public GameObject punt;
	public GameObject next;
	public GameObject enem1;
	public GameObject enem2;
	public GameObject cora1;
	public GameObject cora2;
	public GameObject cora3;
	public GameObject block1;
	public GameObject block2;
	public GameObject block3;
	public GameObject block4;
	public GameObject block5;
	public GameObject block6;
	public GameObject door;
	public GameObject imagen;
	public GameObject exitbtn;
	public GameObject exitno;
	public GameObject exitsi;
	public GameObject textoExit;
	public GameObject fondoExit;
	public Image item;
	public Sprite key;
	public Sprite vel;
	public Sprite plus;
	public Sprite dis;
	public Sprite helt;
	public Sprite escudo;
	public Text dialog;
	bool avalible = true;
	int scen = 0;
	int scene = 1;

	void Start () {
		DataTravel tot = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		tot.scenes = 5;
		StartCoroutine (inic ());
		benvenid.SetActive (true);
		fonmen.SetActive (true);
		exitbtn.SetActive (false);
		punt.SetActive (false);
		exitno.SetActive (false);
		exitsi.SetActive (false);
		textoExit.SetActive (false);
		fondoExit.SetActive (false);
		cora1.SetActive (false);
		cora2.SetActive (false);
		cora3.SetActive (false);
		joystick.SetActive (false);
		dialofgt.SetActive (false);
		dispr.SetActive (false);
		button.SetActive (false);
		button1.SetActive (false);
		next.SetActive (false);
		enem1.SetActive (false);
		enem2.SetActive (false);
		block1.SetActive (false);
		block2.SetActive (false);
		block3.SetActive (false);
		block4.SetActive (false);
		block5.SetActive (false);
		block6.SetActive (false);
		door.SetActive (false);
		imagen.SetActive (false);
	}

	void Update () {
		if( Input.GetKey( KeyCode.Escape ) )
		{
			if(scen == 0){
				Application.Quit();
			}else if(scen == 1){
				exitnon();
			}
			avalible = false;
			StartCoroutine(dispon());
		}
	}

	IEnumerator dispon (){
		yield return new WaitForSeconds(1);
		avalible = true;
	}

	public void exit(){
		exitbtn.SetActive (false);
		exitno.SetActive (true);
		exitsi.SetActive (true);
		textoExit.SetActive (true);
		fondoExit.SetActive (true);
		scen = 1;
	}

	public void exitsis(){
		DataTravel tet = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		tet.tutorial = 1;
		tet.scenes = 0;
		GameObject.FindGameObjectWithTag("MainCamera").SendMessage("tutt");
		Application.LoadLevel("Game");
	}
	
	public void exitnon(){
		exitbtn.SetActive (true);
		exitno.SetActive (false);
		exitsi.SetActive (false);
		textoExit.SetActive (false);
		fondoExit.SetActive (false);
		scen = 0;
	}

	IEnumerator inic(){
		yield return new WaitForSeconds (3);
		next.SetActive (false);
		cora1.SetActive (false);
		cora2.SetActive (false);
		cora3.SetActive (false);
		benvenid.SetActive (false);
		fonmen.SetActive (false);
		exitbtn.SetActive (true);
		button1.SetActive (true);
		dialofgt.SetActive (true);
		dialg.SetActive (true);
		dialog.text = "Pulsa en la parte indicada para activar el Joystick, con este podras moverte en todo el Mapa.";
	}

	public void nextScene(){
		if (scene == 1) {
			joystick.SetActive (true);
			button1.SetActive (false);
			scene = 2;
			StartCoroutine (nix ());
		} else if (scene == 2) {
			GameObject.FindGameObjectWithTag("Player").SendMessage("Disparado");
			dispr.SetActive(true);
			button.SetActive (false);
			StartCoroutine (nex ());
			scene = 3;
		}
	}

	public void nextcuadrp(){
		if (scene == 3) {
			dialog.text = "Al lado de tu puntuacion veras los enemigos restantes.";
			enem1.SetActive (true);
			enem2.SetActive (true);
			scene = 4;
		} else if (scene == 4) {
			dialog.text = "Los corazones indicaran las vidas restantes que tienes.";
			cora1.SetActive(true);
			cora2.SetActive(true);
			cora3.SetActive(true);
			scene = 5;
		} else if (scene == 5) {
			dialog.text = "Encontraras diferentes items rompiendo los bloques, pasa sobre ellos para tomarlos.";
			next.SetActive (false);
			block1.SetActive (true);
			block2.SetActive (true);
			block3.SetActive (true);
			block4.SetActive (true);
			block5.SetActive (true);
			block6.SetActive (true);
			door.SetActive (true);
			StartCoroutine (despa ());
		}
	}

	IEnumerator nix(){
		yield return new WaitForSeconds(5);
		button.SetActive (true);
		dialog.text = "Pulsa en la parte indicada para Disparar, utilizalo para derrotar a tus enemigos.";
	}

	IEnumerator nex(){
		yield return new WaitForSeconds(3);
		punt.SetActive (true);
		next.SetActive (true);
		dialog.text = "En la parte superior izquierda veras tu puntuacion actual.";
	}

	IEnumerator despa(){
		yield return new WaitForSeconds(7);
		dialog.text = "Cuidado!!! Si tu o tus enemigos destruyen los items apareceran mas enemigos.";
		StartCoroutine (llav ());
	}

	IEnumerator llav(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = key;
		dialog.text = "La llave te servira para abrir la puerta y poder pasar de nivel.";
		StartCoroutine (shil ());
	}

	IEnumerator shil(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = escudo;
		dialog.text = "El escudo te protegera de 1 bala del enemigo.";
		StartCoroutine (veli ());
	}

	IEnumerator veli(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = vel;
		dialog.text = "Este item aumentara tu velocidad";
		StartCoroutine (pluss ());
	}

	IEnumerator pluss(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = plus;
		dialog.text = "Con este item podras disparar mas balas al mismo tiempo";
		StartCoroutine (diss ());
	}

	IEnumerator diss(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = dis;
		dialog.text = "Este item aumentara la distancia de tu disparo.";
		StartCoroutine (heltt ());
	}

	IEnumerator heltt(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (true);
		item.sprite = helt;
		dialog.text = "Este item aumentara una vida siempre y cuando sea posible.";
		StartCoroutine (port ());
	}

	IEnumerator port(){
		yield return new WaitForSeconds (4);
		imagen.SetActive (false);
		dialog.text = "Toma la llave y ve a la puerta para salir del tutorial.";
		StartCoroutine (fin ());
	}

	IEnumerator fin(){
		yield return new WaitForSeconds (6);
		imagen.SetActive (false);
		dialofgt.SetActive (false);
		StartCoroutine (hoad ());
	}

	IEnumerator hoad(){
		yield return new WaitForSeconds (12);
		imagen.SetActive (false);
		dialofgt.SetActive (false);
		StartCoroutine (fin ());
	}
}
