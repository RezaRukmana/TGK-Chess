using UnityEngine;
using System.Collections;

public class Knight : Piece {

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
		if(absolute(toNode.y-fromNode.y)==2){
			if(absolute(toNode.x-fromNode.x)!=1)
				return false;
		}
		else if(absolute(toNode.y-fromNode.y)==1){
			if(absolute(toNode.x-fromNode.x)!=2)
				return false;
		}
		else
			return false;
		return true;
	}
}
