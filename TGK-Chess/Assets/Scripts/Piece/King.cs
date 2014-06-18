using UnityEngine;
using System.Collections;

public class King : Piece {
	private int isCastlingMove=-1;

	public override bool checkMove(){
		isCastlingMove = -1;
		Vector2 fromNode = gm.getTileIndex(origin);
		Vector2 toNode = gm.getTileIndex(transform.position);
		if(toNode.x>7||toNode.x<0||toNode.y>7||toNode.y<0)
			return false;
		if(fromNode==toNode)
			return false;
		if(gm.nodes[(int)toNode.x, (int)toNode.y].piece!=null)
			if(gm.nodes[(int)toNode.x, (int)toNode.y].piece.GetComponent<Piece>().owner==owner)
				return false;
		if((absolute(fromNode.y-toNode.y)>1))
			return false;
		if(absolute(fromNode.x-toNode.x)>1){
			if(!firstMove)
				return false;
			if(toNode.x==6&&toNode.y==owner*7){
				for(int i=(int)fromNode.x+1;i<(int)toNode.x;i++){
					if(gm.nodes[i, (int)fromNode.y].piece != null)
						return false;
				}
				if(gm.nodes[(int)toNode.x+1, (int)toNode.y].piece==null)
					return false;
				if(!gm.nodes[(int)toNode.x+1, (int)toNode.y].piece.GetComponent<Piece>().firstMove)
					return false;
				isCastlingMove = 0;
			}
			else if(toNode.x==2&&toNode.y==owner*7){
				for(int i=(int)fromNode.x-1;i>(int)toNode.x;i--){
					if(gm.nodes[i, (int)fromNode.y].piece != null)
						return false;
				}
				if(gm.nodes[(int)toNode.x-2, (int)toNode.y].piece==null)
					return false;
				if(!gm.nodes[(int)toNode.x-2, (int)toNode.y].piece.GetComponent<Piece>().firstMove)
					return false;
				isCastlingMove = 1;
			}
			else
				return false;
		}
		return true;
	}

	public override void move(){
		Vector2 checkPos = gm.getTileIndex(origin);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = null;
		
		checkPos = gm.getTileIndex(transform.position);
		if(gm.nodes[(int)checkPos.x, (int)checkPos.y].piece!=null)
			takePiece(checkPos);
		else if(isCastlingMove>-1)
			castlingMove(checkPos);
		gm.nodes[(int)checkPos.x, (int)checkPos.y].piece = gameObject;
		transform.position = gm.getTileCenter(transform.position);
		firstMove=false;
		GameState.nextTurn();
	}

	void castlingMove(Vector2 toNode){
		if(isCastlingMove==0){
			gm.nodes[(int)toNode.x-1, (int)toNode.y].piece = gm.nodes[(int)toNode.x+1, (int)toNode.y].piece;
			gm.nodes[(int)toNode.x+1, (int)toNode.y].piece = null;
			gm.nodes[(int)toNode.x-1, (int)toNode.y].piece.transform.position = gm.getTileCenter(new Vector2(toNode.x-1, toNode.y));
		}
		else{
			gm.nodes[(int)toNode.x+1, (int)toNode.y].piece = gm.nodes[(int)toNode.x-2, (int)toNode.y].piece;
			gm.nodes[(int)toNode.x-2, (int)toNode.y].piece = null;
			gm.nodes[(int)toNode.x+1, (int)toNode.y].piece.transform.position = gm.getTileCenter(new Vector2(toNode.x+1, toNode.y));
		}
	}
}
