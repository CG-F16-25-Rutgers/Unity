using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Start () {

	}

	void Awake () {
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && !NavController.obstacleSelected)  {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				//sets agent to be moved
				if (NavController.agentClicked == "") {
					if (hit.transform.name == this.transform.name) {
						NavController.agentClicked = this.gameObject.name;
						Debug.Log (this.gameObject.name);
					}
				}
				//moves agent to destination
				else if (NavController.agentClicked == this.gameObject.name) {
					//TODO: make sure destination is legal
					navMeshAgent.destination = hit.point;
					NavController.agentClicked = "";
				} 
			}
		}
	}
}