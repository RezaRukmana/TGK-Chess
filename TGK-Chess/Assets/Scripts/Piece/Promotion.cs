using UnityEngine;
using System.Collections;

public class Promotion : MonoBehaviour {

	public GameObject promoteTo;

	public static Vector2 pos;
	public static int thisTurn;
	private GridManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Board").GetComponent<GridManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		promotion();
		GameState.turn = thisTurn;
		GameState.nextTurn();
		Destroy(transform.parent.gameObject);
	}

	public void promotion(){
		Destroy(gm.nodes[(int)pos.x, (int)pos.y].piece.gameObject);
		GameObject instantiator = (GameObject)Instantiate(promoteTo);
		gm.nodes[(int)pos.x, (int)pos.y].piece = instantiator;
		instantiator.transform.position = gm.getTileCenter(pos);
	}
}
