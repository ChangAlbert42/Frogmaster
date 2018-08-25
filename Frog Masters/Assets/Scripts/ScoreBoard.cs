using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public Text Score_Board;
  

    // Use this for initialization
    void Start () {
        //Score_Board.text = "Leaderboard Scores: \nFrog 1: 0\nFrog 2: 0\nFrog 3: 0\nFrog 4: 0";
    }
	
	// Update is called once per frame
	void Update () {
        Score_Board.text = "Leaderboard Scores:";

        List<GameObject> temp = GetComponent<CameraController>().froglist;
        for(int i = 0; i < temp.Count; i++)
        {
			if (temp[i] != null)
            	Score_Board.text += "\nFrog " + (i+1) + ": " + temp[i].GetComponent<Frog>().points.ToString();
        } 
        /*int frog1 = temp[0].GetComponent<Frog>().points;
        Score_Board.text = "Leaderboard Scores: \nFrog 1: " + Frog.returnPoints().ToString();
            + "\nFrog 2: 0" 
            + "\nFrog 3: 0\nFrog 4: 0";*/
    }
}
