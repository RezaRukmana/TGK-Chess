using UnityEngine;
using System.Collections;

public class WhitePawn : Piece {
	public GameObject promotion;

	public override bool checkMove(){
		isEnPassantMove=false;
		Vector2 fromNode = gm.getTileIndex(origin);
		Vector2 toNode = gm.getTileIndex(transform.position);
		if(toNode.x>7||toNode.x<0||toNode.y>7||toNode.y<0)
			return false;
		if(fromNode==toNode)
			return false;
		if(checkDirection(toNode, fromNode)){
			if(toNode.x==fromNode.x){
				if(gm.nodes[(int)toNode.x, (int)toNode.y].piece!=null)
					return false;
				if(gm.nodes[(int)fromNode.x,(int)fromNode.y-1].piece!=null)
					return false;
			}
			else if(absolute(toNode.x-fromNode.x)==1){
				if(gm.nodes[(int)toNode.x, (int)toNode.y].piece==null){
					if(gm.nodes[(int)toNode.x, (int)toNode.y].enPassant==owner&&GameState.turnNumber-gm.nodes[(int)toNode.x, (int)toNode.y].enPassantTurn==1)
						isEnPassantMove=true;
					else
						return false;
				}
				else if(gm.nodes[(int)toNode.x, (int)toNode.y].piece.GetComponent<Piece>().owner==owner)
					return false;
			}
			else
				return false;
		}
		else
			return false;
		return true;
	}
	
	bool checkDirection(Vector2 to, Vector2 from){
		if(firstMove&&from.y-to.y==2){
			gm.nodes[(int)from.x,(int)from.y-1].enPassant=0;
			gm.nodes[(int)from.x,(int)from.y-1].enPassantTurn=GameState.turnNumber;
			return true;
		}
		return from.y-to.y==1;
	}
	
	private bool isEnPassantMove=false;
	
	void enPassantMove(Vector2 to){
		Destroy(gm.nodes[(int)to.x,(int)to.y+1].piece.gameObject);
		gm.nodes[(int)to.x,(int)to.y+1].piece=null;
	}
	
	public override void move(){
		Vector2 checkPos = gm.getTileIndex(origin);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = null;
		
		checkPos = gm.getTileIndex(transform.position);
		if(gm.nodes[(int)checkPos.x, (int)checkPos.y].piece!=null)
			takePiece(checkPos);
		else if(isEnPassantMove)
			enPassantMove(checkPos);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = gameObject;
		transform.position = gm.getTileCenter(transform.position);
		firstMove=false;
		if((int)checkPos.y==0)
			promote(checkPos);
		else
			GameState.nextTurn();
	}

	void promote(Vector2 pos){
		Promotion.thisTurn = owner;
		GameState.turn=2;
		Promotion.pos = pos;
		promotion = (GameObject)Instantiate(promotion);
	}
}
