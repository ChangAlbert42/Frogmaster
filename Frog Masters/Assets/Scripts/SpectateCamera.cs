using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectateCamera : MonoBehaviour {

	public Transform player;
	public Vector3 offset;
	public List<GameObject> speclist;
	public int playerNumber;
	public CameraController Instance;

	void Start() {
		/*froglist = GameObject.FindGameObjectWithTag("client").GetComponent<NetworkingClient> ().froglist;
		playerNumber = GameObject.FindGameObjectWithTag("client").GetComponent<NetworkingClient> ().playerNumber;*/

		if(GameObject.FindGameObjectWithTag("host").GetComponent<NetworkingHost>() != null)
		{
			speclist = GameObject.FindGameObjectWithTag("host").GetComponent<NetworkingHost>().froglist;
			playerNumber = GameObject.FindGameObjectWithTag("host").GetComponent<NetworkingHost>().playerNumber;
		}


		//Assign ();
	}

	/*void Assign(){
		for (int i = 0; i < froglist.Count; i++) {
			if (playerNumber == froglist [i].GetComponent<Frog> ().playerNumber) {
				player = froglist[i].transform;
			}
		}
	}*/

	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
			transform.position = new Vector3 (0, player.position.y + 5, offset.z);
		if(Input.GetKeyDown(KeyCode.DownArrow))
			transform.position = new Vector3 (0, player.position.y - 5, offset.z);
	}
}

