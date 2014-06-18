using UnityEngine;
using System.Collections;

public abstract class Piece : MonoBehaviour {

	public Vector3 origin;
	public GridManager gm;
	public int owner; //0=black, 1=white
	
	public bool firstMove;
	public bool isEnabled;

	// Use this for initialization
	void Start () {
		firstMove = true;
		origin = transform.position;
		gm = GameObject.FindGameObjectWithTag("Board").GetComponent<GridManager>();
	}

	void Update(){
		if(GameState.turn==owner)
			isEnabled=true;
		else
			isEnabled=false;
	}

	void OnMouseDown(){
		if(isEnabled)
			origin = transform.position;
	}

	void OnMouseDrag () {
		if(isEnabled){
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z = origin.z;
			transform.position = pos;
			if(gm.getTileCenter(pos)!=gm.getTileCenter(origin))
				gm.highLight(pos, true, checkMove());
			else
				gm.highLight(transform.position,false,false);
		}
	}

	void OnMouseUp () {
		if(isEnabled){
			gm.highLight(transform.position,false,false);
			if(checkMove())
				move ();
			else
				transform.position = origin;
		}
	}

	public virtual void move(){
		Vector2 checkPos = gm.getTileIndex(origin);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = null;
		
		checkPos = gm.getTileIndex(transform.position);
		if(gm.nodes[(int)checkPos.x, (int)checkPos.y].piece!=null)
			takePiece(checkPos);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = gameObject;
		transform.position = gm.getTileCenter(transform.position);
		firstMove=false;
		GameState.nextTurn();
	}

	public void takePiece(Vector2 checkPos){
		Destroy(gm.nodes[(int)checkPos.x, (int)checkPos.y].piece.gameObject);
		if(gm.nodes[(int)checkPos.x, (int)checkPos.y].piece.GetComponent<King>()!=null)
			GameState.turn=3+owner;
	}

	public abstract bool checkMove();

	public float absolute(float i){
		if(i<0)
			return -i;
		return i;
	}
}
