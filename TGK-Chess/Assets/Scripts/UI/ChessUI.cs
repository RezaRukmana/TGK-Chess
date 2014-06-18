using UnityEngine;
using System.Collections;

public class ChessUI : MonoBehaviour {

	public GUIStyle chessStyle;
	private Rect rectTurn;
	private string turn;

	// Use this for initialization
	void Start () {
		rectTurn.width = Screen.width*0.3f;
		rectTurn.height = Screen.height*0.1f;
		rectTurn.x = (Screen.width*(1-0.3f))/2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GameState.turn==0)
			turn="Black Turn";
		else if(GameState.turn==1)
			turn="White Turn";
		else if(GameState.turn==2)
			turn="Promote!";
		else if(GameState.turn==3)
			turn="Black Wins!";
		else if(GameState.turn==4)
			turn="White Wins!";
		else
			turn="Draw";
		GUI.Label(rectTurn, turn, chessStyle);
	}
}
