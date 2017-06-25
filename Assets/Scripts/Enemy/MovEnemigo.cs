using UnityEngine;
using System.Collections;

public class MovEnemigo : MonoBehaviour {
	Transform yo;
	Rigidbody2D yorb;
	public Transform salidaBalaEnm;
	public GameObject balaEnm;
	public GameObject fueg;
	public float enmSpeed = 0.05f;
	public float arreglo = 0.1f;
	public int dispMax = 1;
	public int beneficio = 100;
	public float vidaE = 100f;
	public float bala = 100f;
	public float explo = 50f;
	public float attk;
	float time;
	int spa;

	void Start () { 
		yo = GetComponent<Transform> ();
		yorb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("Atacck", 1f, Random.Range (2f, 3f));
		spa = 1;
	}

	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			time = Random.Range(2.0f,9.0f);
			ranDireccion();
		}
		yorb.velocity = yorb.transform.TransformDirection(Vector2.up * enmSpeed);
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Bala") {
			vidaE -= bala;
			if (vidaE <= 0){
				Freno ();
				Destroy (gameObject, 4f);
				if (spa == 1) {
					spa = 0;
					fueg.SetActive(true);
					yorb.isKinematic = true;
					SpawnCenter discon = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
					discon.enmMax += 1;
					discon.enmRest -= 1;
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
					Respawn ben = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Respawn> ();
					ben.puntaje += beneficio;
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Puntos");
				}
			}
		} else if (other.gameObject.tag == "Player") {
		} else if (other.gameObject.tag == "Explosivo" || other.gameObject.tag == "ExploEnm") {
			vidaE -= explo;
			if (vidaE <= 0){
				Freno ();
				Destroy (gameObject, 4f);
				if (spa == 1) {
					spa = 0;
					fueg.SetActive(true);
					yorb.isKinematic = true;
					SpawnCenter discon = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<SpawnCenter> ();
					discon.enmMax += 1;
					discon.enmRest -= 1;
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Spawn");
					Respawn ben = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Respawn> ();
					ben.puntaje += beneficio;
					GameObject.FindGameObjectWithTag ("Spawn").SendMessage ("Puntos");
				}
			}
		} else {
			ranDireccion ();
		}
	}

	void ranDireccion(){
		if(transform.eulerAngles.z <= 45f || transform.eulerAngles.z >= 315.111f){
			Arriba();
		}else if(transform.eulerAngles.z >= 135.111 && transform.eulerAngles.z <= 225f){
			Abajo();
		}else if(transform.eulerAngles.z >= 225.111f && transform.eulerAngles.z <= 315f){
			Derecha();
		}else if(transform.eulerAngles.z >= 45.111f && transform.eulerAngles.z <= 135f){
			Izquierda();
		}else{
			Error();
		}
	}

	void Arriba(){
		float range = Random.Range(1.0f,4.0f);
		yo.position = transform.position - Vector3.up * arreglo;
		if (range >= 1f && range <= 1.999f){
			yo.rotation = Quaternion.Euler (0, 0, 270);
		}else if(range >= 2f && range <= 2.999f){
			yo.rotation = Quaternion.Euler (0, 0, 180);
		}else if(range >=3f && range <= 4f){
			yo.rotation = Quaternion.Euler (0, 0, 90);
		}
	}

	void Abajo(){
		float range = Random.Range(1.0f,4.0f);
		yo.position = transform.position - Vector3.down * arreglo;
		if (range >= 1f && range <= 1.999f){
			yo.rotation = Quaternion.Euler (0, 0, 270);
		}else if(range >= 3f && range <= 4f){
			yo.rotation = Quaternion.Euler (0, 0, 0);
		}else if(range >=2f && range <= 2.999f){
			yo.rotation = Quaternion.Euler (0, 0, 90);
		}
	}

	void Derecha(){
		float range = Random.Range(1.0f,4.0f);
		yo.position = transform.position - Vector3.right * arreglo;
		if (range >= 1f && range <= 1.999f){
			yo.rotation = Quaternion.Euler (0, 0, 0);
		}else if(range >= 2f && range <= 2.999f){
			yo.rotation = Quaternion.Euler (0, 0, 180);
		}else if(range >=3f && range <= 4f){
			yo.rotation = Quaternion.Euler (0, 0, 90);
		}
	}

	void Izquierda(){
		float range = Random.Range(1.0f,4.0f);
		yo.position = transform.position - Vector3.left * arreglo;
		if (range >= 1f && range <= 1.999f){
			yo.rotation = Quaternion.Euler (0, 0, 270);
		}else if(range >= 2f && range <= 2.999f){
			yo.rotation = Quaternion.Euler (0, 0, 180);
		}else if(range >=3f && range <= 4f){
			yo.rotation = Quaternion.Euler (0, 0, 0);
		}
	}

	void Error(){
		yo.rotation = Quaternion.Euler (0, 0, 0);
	}

	void Atacck(){
		if (attk != 0 && dispMax > 0) {
			Instantiate (balaEnm, new Vector3 (salidaBalaEnm.position.x, salidaBalaEnm.position.y, -2), yo.transform.rotation);
			dispMax -= 1;
		} else {
			GameObject.FindGameObjectWithTag("EnemCenter").SendMessage("comprobar");
		}
	}

	void Freno(){
		enmSpeed = 0;
		attk = 0;
		time = 35;
	}
}