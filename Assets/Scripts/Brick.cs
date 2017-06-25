using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public float vida = 100f;
	public float dbala = 101f;
	public SpriteRenderer brick;
	public Sprite dañad;
	float dexplosiv = 49f;

	void Start () {
		brick = GetComponent<SpriteRenderer>();
	}

	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.tag == "Bala" || otherObj.gameObject.tag == "BalaEnm") {
			vida -= dbala;
			if (vida <= 0) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Explosivo" || other.gameObject.tag == "ExploEnm") {
			vida -= dexplosiv;
			if (vida <= 50){
				brick.sprite = dañad;
			} 
			if(vida <= 0){
				Destroy(gameObject);
			}
		}
	}
}
