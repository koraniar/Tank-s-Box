using UnityEngine;
using System.Collections;

public class HealtItem : MonoBehaviour {

	public AudioSource dips;
	public int dispMax = 1;
	public float vida = 100;
	public float balaDiscont = 100;
	public float explo = 50f;
	public float balDis = 0.5f;
	public bool shield = false;
	public Transform salidaBala;
	public GameObject bala;
	public GameObject vibrand;
	public Rigidbody2D yo;
	Transform tank;
	public bool vi = true;
	public Animator canvas;
	bool efxts;
	float vidass;
	int menPuntua;
	int punta;

	void Start () {
		tank = GetComponent<Transform>();
		efect ();
	}

	public void actial(){
		DataTravel pen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		menPuntua = int.Parse(pen.pun5);
	}

	void OnCollisionEnter2D (Collision2D other){
		Physics2D.IgnoreLayerCollision (8, 14);
		if (other.gameObject.tag == "BalaEnm") {
			if (shield){
				shield = false;
			}else{
				vida -= balaDiscont;
				if (vida <= 0){
					PlayerControler lo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
					lo.vivo = false;
					dispMax = -5;
					if (vi){
						vi = false;
						GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spw");
						GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Corazones");
						yo.isKinematic = true;
						Respawn ved = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
						vidass = ved.vidas;
						punta = ved.puntaje;
						if(vidass <= 0f){
							if(punta >= menPuntua){
								canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
								canvas.Play("CanNomb");
							}else{
								GameObject.FindGameObjectWithTag("Spawn").SendMessage("perdi");
							}
						}
					}
				}
			}
		} else if (other.gameObject.tag == "Key") {
			DoorExit llave = GameObject.FindGameObjectWithTag("door").GetComponent<DoorExit>();
			llave.key = true;
		} else if (other.gameObject.tag == "Shield") {
			shield = true;
		} else if (other.gameObject.tag == "BalaDis") {
			balDis += 0.5f;
		} else if (other.gameObject.tag == "BalaPlus") {
			dispMax +=1;
		} else if (other.gameObject.tag == "Healtim") {
			Respawn ru = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
			ru.vidas += 1; 
			GameObject.FindGameObjectWithTag("Spawn").SendMessage("Corazones");
		} else if (other.gameObject.tag == "Velocity") {
			PlayerControler vels = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
			vels.MovementSpeed += 0.03f;
			if (vels.MovementSpeed >= 0.11f){
				vels.MovementSpeed = 0.11f;
			}
		}else if (other.gameObject.tag == "ExploEnm") {
			vida -= explo;
			Instantiate (vibrand, new Vector3 (0, 0, 0), Quaternion.identity);
			Vibrate dure = GameObject.FindGameObjectWithTag("Vibra").GetComponent<Vibrate>();
			dure.vibDurac = 0.15f;
			if (vida <= 0){
				PlayerControler lo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
				lo.vivo = false;
				dispMax = -5;
				if (vi){
					vi = false;
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spw");
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Corazones");
					yo.isKinematic = true;
					Respawn ved = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Respawn>();
					vidass = ved.vidas;
					punta = ved.puntaje;
					if(vidass <= 0f){
						if(punta >= menPuntua){
							canvas.cullingMode = AnimatorCullingMode.AlwaysAnimate;
							canvas.Play("CanNomb");
						}else{
							GameObject.FindGameObjectWithTag("Spawn").SendMessage("perdi");
						}
					}
				}
			}
		} 
	}

	public void kinem(){
		yo.isKinematic = false;
	}

	public void efect(){
		DataTravel efcds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (efcds.efectos == 1) {
			efxts = true;
		}else{
			efxts = false;
		}
	}

	public void Disparado(){
		if (dispMax > 3) {
			dispMax = 3;
		}
		if (dispMax > 0) {
			Instantiate (bala, new Vector3 (salidaBala.position.x, salidaBala.position.y, -2), tank.transform.rotation);
			if (efxts){
				dips.Play();
			}
			dispMax -= 1;
		}
	}
}
