using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Respawn : MonoBehaviour {

	public Text puntos;
	public int puntaje = 0;
	public GameObject player;
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public GameObject effect;
	public Transform spwn;
	public float vidas = 3;
	public float camx = 0f;
	public float camy = 0f;

	void Start () {
		puntos.text = puntaje.ToString();
		inicio2 ();
	}

	public void inicio2(){
		Camera.main.transform.position = new Vector3(camx,camy,-10f);
		player.transform.position = new Vector3(spwn.position.x, spwn.position.y, -3);
		player.transform.rotation = Quaternion.Euler (0, 0, 0);
		Puntos ();
		Corazones ();
	}

	public void Spw(){
		vidas -= 1;
		Instantiate (effect, new Vector3 (player.transform.position.x, player.transform.position.y, -6), player.transform.rotation);
		Corazones ();
		StartCoroutine(Spawna());
	}
	IEnumerator Spawna() {
		yield return new WaitForSeconds(4);
		if (vidas > 0f) {
			Camera.main.transform.position = new Vector3(camx,camy,-10f);
			player.transform.position = new Vector3(spwn.position.x, spwn.position.y, 0);
			player.transform.rotation = Quaternion.Euler (0, 0, 0);
			GameObject.FindGameObjectWithTag ("Player").SendMessage ("kinem");
			HealtItem count = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtItem>();
			count.dispMax = 1;
			count.shield = false;
			count.balDis = 0.5f;
			count.vida = 100;
			count.vi = true;
			PlayerControler vivo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
			vivo.vivo = true;
			vivo.MovementSpeed= 0.05f;
		}
	}

	public void Puntos(){
		puntos.text = puntaje.ToString();
	}

	public void Corazones(){
		if (vidas > 3) {
			vidas = 3;
		}
		if (vidas == 3) {
			heart1.SetActive(true);
			heart2.SetActive(true);
			heart3.SetActive(true);
		} else if (vidas == 2) {
			heart1.SetActive(false);
			heart2.SetActive(true);
			heart3.SetActive(true);
		} else if (vidas == 1) {
			heart1.SetActive(false);
			heart2.SetActive(false);
			heart3.SetActive(true);
		} else if (vidas <= 0) {
			heart1.SetActive(false);
			heart2.SetActive(false);
			heart3.SetActive(false);
		}
	}
}
