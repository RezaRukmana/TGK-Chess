using UnityEngine;
using System.Collections;

public class Rook : Piece {

	public override bool checkMove(){
		Vector2 fromNode = gm.getTileIndex(origin);
		Vector2 toNode = gm.getTileIndex(transform.position);
		if(toNode.x>7||toNode.x<0||toNode.y>7||toNode.y<0)
			return false;
		if(fromNode==toNode)
			return false;
		if(gm.nodes[(int)toNode.x, (int)toNode.y].piece!=null)
			if(gm.nodes[(int)toNode.x, (int)toNode.y].piece.GetComponent<Piece>().owner==owner)
				return false;
		if(fromNode.x==toNode.x){
			if(fromNode.y<toNode.y){
				for(int i=(int)fromNode.y+1;i<(int)toNode.y;i++){
					if(gm.nodes[(int)fromNode.x, i].piece != null)
						return false;
				}
			}
			else{
				for(int i=(int)fromNode.y-1;i>(int)toNode.y;i--){
					if(gm.nodes[(int)fromNode.x, i].piece != null)
						return false;
				}
			}
		}
		else if(fromNode.y==toNode.y){
			if(fromNode.x<toNode.x){
				for(int i=(int)fromNode.x+1;i<(int)toNode.x;i++){
					if(gm.nodes[i, (int)fromNode.y].piece != null)
						return false;
				}
			}
			else{
				for(int i=(int)fromNode.x-1;i>(int)toNode.x;i--){
					if(gm.nodes[i, (int)fromNode.y].piece != null)
						return false;
				}
			}
		}
		else
			return false;

		return true;
	}
}
