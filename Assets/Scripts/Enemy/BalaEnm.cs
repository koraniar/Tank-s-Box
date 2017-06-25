using UnityEngine;
using System.Collections;

public class BalaEnm : MonoBehaviour {
	Rigidbody2D balaEnm;
	public GameObject enemyG;
	public float velocity = 8f;

	void Start () {
		balaEnm = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		balaEnm.velocity = balaEnm.transform.TransformDirection(Vector2.up * velocity);
	}

	void OnCollisionEnter2D (Collision2D other){
		Physics2D.IgnoreLayerCollision (10, 11);
		Physics2D.IgnoreLayerCollision (11, 12);
		if (other.gameObject.tag == "Enemigo") {
		} else {
			Destroy (gameObject);
			EnemyCenter discon = GameObject.FindGameObjectWithTag("EnemCenter").GetComponent<EnemyCenter>();
			discon.balas += 1;
			GameObject.FindGameObjectWithTag("EnemCenter").SendMessage ("Asignar");
		}
	}

	public void destro(){
		Destroy (gameObject);
	}
}