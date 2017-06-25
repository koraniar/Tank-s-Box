using UnityEngine;
using System.Collections;

public class TankEffect : MonoBehaviour {

	public float time = 7;
	public bool player = false;
	public bool vibra = false;
	public bool efex = true;
	public AudioSource expl;
	public GameObject explosion;
	public GameObject vibrand;
	bool vibro = false;

	void Start () {
		DataTravel datef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (datef.efectos == 1) {
			efex = true;
		} else {
			efex = false;
		}
	}

	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			Destroy(gameObject);
		}
		if( time <= 4){
			explosion.SetActive(true);
			if (!efex){
				expl.Stop();
			}
			if(player){
				if(vibra){
					if(!vibro){
						vibro = true;
						Instantiate (vibrand, new Vector3 (0, 0, 0), Quaternion.identity);
					}
				}
			}
		}
	}
}
