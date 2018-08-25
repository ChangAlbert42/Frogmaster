using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour {
    public float timeRemaining;
    public Text TimeLeft;
	public int Winner = 0;
	public int player = 0;
    //    int p1points;
    //    int p2points;

    // Use this for initialization
    void Start () {
        TimeLeft.text = "Time Remaining: " + timeRemaining.ToString();
    }

    // Update is called once per frame
    void Update () {
		List<GameObject> temp = GetComponent<CameraController>().froglist;
        timeRemaining -= Time.deltaTime;
		if (timeRemaining > 0)
			TimeLeft.text = "Time Remaining: " + ((int)timeRemaining).ToString ();
		else {
			for (int i = 0; i < temp.Count; i++) {
				if (temp [i].GetComponent<Frog> ().points > Winner) {
					Winner = temp [i].GetComponent<Frog> ().points;
					player = temp [i].GetComponent<Frog> ().playerNumber;
				}
			}
			if (GameObject.FindGameObjectWithTag ("host").GetComponent<NetworkingHost> () != null) {
				if (GameObject.FindGameObjectWithTag ("host").GetComponent<NetworkingHost> ().playerNumber == player) {
					GameObject.FindGameObjectWithTag ("host").GetComponent<NetworkingHost> ().gameStarted = false;

					SceneManager.LoadScene ("P1Win");
				} else {
					GameObject.FindGameObjectWithTag ("host").GetComponent<NetworkingHost> ().gameStarted = false;
					SceneManager.LoadScene ("Lose");
				}
			} else{
				if (GameObject.FindGameObjectWithTag ("host").GetComponent<NetworkingClient> ().playerNumber == player) {

					SceneManager.LoadScene ("P1Win");
				} else {
					SceneManager.LoadScene ("Lose");
				}
			}
				
		}
    }
}

    