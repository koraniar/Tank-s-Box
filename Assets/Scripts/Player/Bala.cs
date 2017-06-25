using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	Rigidbody2D bala;
	public float velocity = 8f;
	public float distancia = 1f;
	
	void Start () {
		bala = GetComponent<Rigidbody2D> ();
		HealtItem act = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtItem>();
		distancia = act.balDis;
		StartCoroutine (destruir ());
	}

	void Update () {
		bala.velocity = bala.transform.TransformDirection(Vector2.up * velocity);
	}

	void OnCollisionEnter2D (Collision2D other){
		Physics2D.IgnoreLayerCollision (9, 12);
		if (other.gameObject.tag == "Player") {
		} else {
			Destroy (gameObject);
			HealtItem discon = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtItem>();
			discon.dispMax += 1;
		}
	}

	IEnumerator destruir(){
		yield return new WaitForSeconds (distancia);
		HealtItem discon = GameObject.FindGameObjectWithTag("Player").GetComponent<HealtItem>();
		discon.dispMax += 1;
		Destroy (gameObject);
	}
}
