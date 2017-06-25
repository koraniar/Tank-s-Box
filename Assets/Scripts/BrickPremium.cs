using UnityEngine;
using System.Collections;

public class BrickPremium : MonoBehaviour {
	
	public float vida = 100f;
	public float dbala = 101f;
	public SpriteRenderer bricked;
	public Sprite dañad;
	public GameObject item;
	public GameObject vel;
	public GameObject healt;
	public GameObject plus;
	public GameObject dis;
	public GameObject shild;
	public bool ttutorial = true;
	bool intance = true;
	Transform brick;
	float dexplosiv = 49f;

	void Start () {
		brick = GetComponent<Transform> ();
		bricked = GetComponent<SpriteRenderer>();
		if (!ttutorial){
			float spawn = Random.Range (0.0f, 6.0f);
			if(spawn <= 1.1f){
				item = vel;
			}else if (spawn > 1.1f && spawn <= 2.2f){
				item = healt;
			}else if (spawn > 2.2f && spawn <= 3.3f){
				item = plus;
			}else if (spawn > 3.3f && spawn <= 4.4f){
				item = dis;
			}else if (spawn > 4.4f && spawn <= 5.5f){
				item = shild;
			}else if (spawn > 5.5f){
				intance = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.tag == "Bala" || otherObj.gameObject.tag == "BalaEnm") {
			vida -= dbala;
			if (vida <= 0) {
				if (intance){
					Instantiate (item, new Vector3 (brick.position.x, brick.position.y, 1), Quaternion.identity);
				}
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Explosivo" || other.gameObject.tag == "ExploEnm") {
			vida -= dexplosiv;
			if (vida <= 50){
				bricked.sprite = dañad;
			} 
			if(vida <= 0){
				if (intance){
					Instantiate (item, new Vector3 (brick.position.x, brick.position.y, 1), Quaternion.identity);
				}
				Destroy(gameObject);
			}
		}
	}
}