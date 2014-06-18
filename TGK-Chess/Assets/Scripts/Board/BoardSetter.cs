using UnityEngine;
using System.Collections;

public class BoardSetter : MonoBehaviour {

	public GameObject whiteKing;
	public GameObject whiteQueen;
	public GameObject whitePawn;
	public GameObject whiteKnight;
	public GameObject whiteBishop;
	public GameObject whiteRook;
	public GameObject blackKing;
	public GameObject blackQueen;
	public GameObject blackPawn;
	public GameObject blackKnight;
	public GameObject blackBishop;
	public GameObject blackRook;

	private GridManager gm;
	private GameObject instantiator;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("Board").GetComponent<GridManager>();
		setBoard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setBoard(){
		for(int i=0;i<8;i++){
			instantiator = (GameObject)Instantiate(blackPawn);
			instantiator.transform.position = gm.nodes[i,1].position;
			gm.nodes[i,1].piece = instantiator;
		}
		instantiator = (GameObject)Instantiate(blackKing);
		instantiator.transform.position = gm.nodes[4,0].position;
		gm.nodes[4,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackQueen);
		instantiator.transform.position = gm.nodes[3,0].position;
		gm.nodes[3,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackRook);
		instantiator.transform.position = gm.nodes[0,0].position;
		gm.nodes[0,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackRook);
		instantiator.transform.position = gm.nodes[7,0].position;
		gm.nodes[7,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackBishop);
		instantiator.transform.position = gm.nodes[2,0].position;
		gm.nodes[2,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackBishop);
		instantiator.transform.position = gm.nodes[5,0].position;
		gm.nodes[5,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackKnight);
		instantiator.transform.position = gm.nodes[1,0].position;
		gm.nodes[1,0].piece = instantiator;
		instantiator = (GameObject)Instantiate(blackKnight);
		instantiator.transform.position = gm.nodes[6,0].position;
		gm.nodes[6,0].piece = instantiator;


		for(int i=0;i<8;i++){
			instantiator = (GameObject)Instantiate(whitePawn);
			instantiator.transform.position = gm.nodes[i,6].position;
			gm.nodes[i,6].piece = instantiator;
		}
		instantiator = (GameObject)Instantiate(whiteKing);
		instantiator.transform.position = gm.nodes[4,7].position;
		gm.nodes[4,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteQueen);
		instantiator.transform.position = gm.nodes[3,7].position;
		gm.nodes[3,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteRook);
		instantiator.transform.position = gm.nodes[0,7].position;
		gm.nodes[0,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteRook);
		instantiator.transform.position = gm.nodes[7,7].position;
		gm.nodes[7,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteBishop);
		instantiator.transform.position = gm.nodes[2,7].position;
		gm.nodes[2,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteBishop);
		instantiator.transform.position = gm.nodes[5,7].position;
		gm.nodes[5,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteKnight);
		instantiator.transform.position = gm.nodes[1,7].position;
		gm.nodes[1,7].piece = instantiator;
		instantiator = (GameObject)Instantiate(whiteKnight);
		instantiator.transform.position = gm.nodes[6,7].position;
		gm.nodes[6,7].piece = instantiator;
	}
}
