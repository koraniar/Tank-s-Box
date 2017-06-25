using UnityEngine;
using System.Collections;

public class pruebas : MonoBehaviour {

	public float MovementSpeed = 0.05f;
	public bool vivo = true;
	private Transform _transform;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerControler pyf = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControler> ();
		MovementSpeed = pyf.MovementSpeed;
		vivo = pyf.vivo;
		if (vivo) {
			if (Input.GetKeyDown ("space")) {
				GameObject.FindGameObjectWithTag("Player").SendMessage("Disparado");
			}
			if (Input.GetKeyDown ("s")) {
				_transform.position = transform.position - Vector3.up * MovementSpeed;
				_transform.rotation = Quaternion.Euler (0, 0, 180);
			} else if (Input.GetKeyDown ("w")) {
				_transform.position = transform.position - Vector3.down * MovementSpeed;
				_transform.rotation = Quaternion.Euler (0, 0, 0);
			} else if (Input.GetKeyDown ("d")) {
				_transform.position = transform.position - Vector3.left * MovementSpeed;
				_transform.rotation = Quaternion.Euler (0, 0, 270);
			} else if (Input.GetKeyDown ("a")) {
				_transform.position = transform.position - Vector3.right * MovementSpeed;
				_transform.rotation = Quaternion.Euler (0, 0, 90);
			}
		}
	}
}
