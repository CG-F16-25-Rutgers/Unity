using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed;
	public float sensitivity;

	//public float minY = -60;
	//public float maxY = 60;

	float rotationY = 0;
	float rotationX = 0;
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Free Look Camera
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (new Vector3 (0, 0, -speed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
		}

		if(Input.GetKey (KeyCode.Mouse0)){
			rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivity;

			rotationY += Input.GetAxis("Mouse Y") * sensitivity;
			//rotationY = Mathf.Clamp (rotationY, minY, maxY);

			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
	}
}
