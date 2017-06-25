using UnityEngine;
using System.Collections;

public class Vibrate : MonoBehaviour {

	public float vibDurac = 0.6f; 

	void Start () {
		DataTravel djf = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataTravel>();
		if (djf.vibracion == 0) {
			Destroy(gameObject);
		}
		Destroy(gameObject,vibDurac);
	}

	void Update () {
		Handheld.Vibrate();
	}
}
