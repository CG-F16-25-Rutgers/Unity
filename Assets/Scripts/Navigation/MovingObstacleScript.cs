using UnityEngine;
using System.Collections;
using System;

public class MovingObstacleScript : MonoBehaviour {

	public const double MAX_TIME_TO_CLICK = 2;
	public const double MIN_TIME_TO_CLICK = 0.05;

	private TimeSpan maxDuration = TimeSpan.FromSeconds(MAX_TIME_TO_CLICK);
	private TimeSpan minDuration = TimeSpan.FromSeconds(MIN_TIME_TO_CLICK);

	public float speed;
	private Color rendColor;
	private System.Diagnostics.Stopwatch timer;
	private bool clickedOnce = false;
	private bool clickedTwice = false;

	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		//moving obstacles (double click required to select)
		if ((Input.GetMouseButtonDown (0) && NavController.obstacleSelected == false) || clickedTwice) {
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit) && hit.transform.name == transform.name) {
				//otherwise this just a regular destination point for an agent, which is not handled here
				if (NavController.agentClicked.Equals ("")) {
					//first click
					if (!clickedOnce) {
						if (!clickedTwice) {
							timer = System.Diagnostics.Stopwatch.StartNew ();
							clickedOnce = true;
						} 
					} //second click 
					else {
						if (timer.Elapsed > minDuration && timer.Elapsed < maxDuration) {
							Debug.Log ("obstacle selected");
							NavController.obstacleSelected = true;
							rendColor = rend.material.color;
							rend.material.color = Color.grey;
							clickedTwice = true;
						}
						clickedOnce = false;
					}
				}
			}
			if (clickedTwice) {//either deselect or move obstacle
				Debug.Log ("clicked twice");
				if (!Input.GetKey (KeyCode.Escape)) {
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

				} else {
					rend.material.color = rendColor;
					clickedTwice = false;
					NavController.obstacleSelected = false;
				}
			}
		}
	}
}
