using UnityEngine;
using System.Collections;
using System;

public class Node : IComparable {
	public float nodeTotalCost;
	public float estimatedCost;
	public bool isObstacle;
	public Node parent;
	public Vector3 position;

	public GameObject piece;
	public int enPassant = -1;
	public int enPassantTurn;

	// Use this for initialization
	public Node () {
		this.estimatedCost = 0.0f;
		this.estimatedCost = 1.0f;
		this.isObstacle = false;
		this.parent = null;
	}

	public Node (Vector3 position) {
		this.estimatedCost = 0.0f;
		this.estimatedCost = 1.0f;
		this.isObstacle = false;
		this.parent = null;
		this.position = position;
	}

	public void markAsObstacle () {
		this.isObstacle = true;
	}

	#region IComparable implementation

	public int CompareTo (object obj)
	{
		Node node = (Node)obj;
		if(this.estimatedCost < node.estimatedCost){
			return -1;
		}else if(this.estimatedCost > node.estimatedCost){
			return 1;
		}
		return 0;
	}

	#endregion
}
