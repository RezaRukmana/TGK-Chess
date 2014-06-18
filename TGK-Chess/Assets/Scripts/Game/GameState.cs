using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int turn=1;//0=black, 1=white
	public static int turnNumber=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void nextTurn(){
		if(turn==0)
			turn=1;
		else if(turn==1)
			turn=0;
		turnNumber++;
	}
}
