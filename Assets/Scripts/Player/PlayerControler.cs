using UnityEngine;
using CnControls;

public class PlayerControler : MonoBehaviour {
	public float MovementSpeed = 0.05f;
	public bool vivo = true;
	
	private Transform _mainCameraTransform;
	private Transform _transform;
	
	private void OnEnable(){
		_mainCameraTransform = Camera.main.GetComponent<Transform>();
		_transform = GetComponent<Transform>();
	}
	
	public void Update(){
		if (vivo) {
			var inputVector = new Vector2 (CnInputManager.GetAxis ("Horizontal"), CnInputManager.GetAxis ("Vertical"));
			Vector3 movementVector = Vector2.zero;
			if (inputVector.sqrMagnitude > 0.001f) {
				movementVector = _mainCameraTransform.TransformDirection (inputVector);
				if (movementVector.x == 1) {
					_transform.position = transform.position - Vector3.left * MovementSpeed;
					_transform.rotation = Quaternion.Euler (0, 0, 270);
				} else if (movementVector.x == -1) {
					_transform.position = transform.position - Vector3.right * MovementSpeed;
					_transform.rotation = Quaternion.Euler (0, 0, 90);
				} else if (movementVector.y == 1) {
					_transform.position = transform.position - Vector3.down * MovementSpeed;
					_transform.rotation = Quaternion.Euler (0, 0, 0);
				} else if (movementVector.y == -1) {
					_transform.position = transform.position - Vector3.up * MovementSpeed;
					_transform.rotation = Quaternion.Euler (0, 0, 180);
				}
			}
		}
	}
}
