using System;
using UnityEngine;

public class ChessRunner : MonoBehaviour
{
    private int START_TIME = 600;
    private int START_MOVE_TIME = 180;
    public static Player currentPlayer;
    private static Player nextPlayer;
    private Boolean playing = false;
    private static Player[] playerList = new Player[2];
    private static ChessPiece[] boardPieces = new ChessPiece[32];
    private int gamesPlayed = 0;
    public static BoardNode[] bNodes = new BoardNode[90];

    public static ChessPiece pieceSelected;
    public static Boolean isSelecting;


    public static ChessPiece getPieceObj(GameObject gObject) {
        for (int i = 0; i < 32; i ++) {
            ChessPiece p = boardPieces[i];
            if (p != null && p.getAssignedObj().Equals(gObject)) {
                 return p;
            }
        }
        return null;
    }

    public static BoardNode getNodeObj(GameObject gObject) {
        for (int i = 0; i < bNodes.Length; i++) {
            BoardNode b = bNodes[i];
            if (b.getAssignedObj().Equals(gObject)) {
                 return b;
            }
        }
        return null;
    }

    public static BoardNode getNodeObj(Vector3 v3) {
        for (int i = 0; i < 90; i++) {
            BoardNode b = bNodes[i];
            if ((v3 - b.getCoords()).magnitude <= 0.1 && pieceSelected != null) {
                return b;
            }
        }
        return null;
    }

    public static BoardNode getNodeObj(int row, int col) {
        for (int i = 0; i < 90; i++) {
            BoardNode b = bNodes[i];
            if (b.getRow() == row && b.getCol() == col) {
                return b;
            }
        }
        return null;
    }

    private ChessPiece createPiece(string name, BoardNode assignedNode, string pColor) {
        switch(name) {
            case "Soldier":
                return new Soldier(assignedNode, name, pColor);
            case "Horse":
                return new Horse(assignedNode, name, pColor);
            case "Advisor":
                return new Advisor(assignedNode, name, pColor);
            case "General":
                return new General(assignedNode, name, pColor);
            case "Rook":
                return new Rook(assignedNode, name, pColor);
            case "Elephant":
                return new Elephant(assignedNode, name, pColor);
            case "Cannon":
                return new Cannon(assignedNode, name, pColor);

        }
        return null;
    }

    private void setup() {
        for (int i = 0; i < 32; i ++) {
            ChessPiece p = boardPieces[i];
            if (p != null) {
                if (p.getAssignedObj() == null) {
                    p.setObj(GameObject.Find($"/{p.getColor()}{p.getAssignedNode().getAssignedObj().tag}"));
                    p.getAssignedObj().transform.parent = GameObject.Find("Pieces").transform;
                }
                //Debug.Log(p);
                BoardNode theNode = p.getStartingNode();
                p.move(theNode);
             }
        }
    }

    public static void switchPlayers() {
        Player cPlayer = currentPlayer;
        currentPlayer = nextPlayer;
        nextPlayer = cPlayer;
    }

    void Start()
    {
        playerList[0] = new Player("Red", START_TIME, START_MOVE_TIME);
        playerList[1] = new Player("Black", START_TIME, START_MOVE_TIME);

        currentPlayer = playerList[0];
        nextPlayer = playerList[1];
        
        playing = true;

        int aPos = 0;
        int bPos = 0;

        foreach (Transform nodeObj in GameObject.Find("Nodes").GetComponentsInChildren<Transform>()) {
            string nodeName = nodeObj.name;
            if (!nodeName.Equals("Nodes")) {
                BoardNode n = new BoardNode(nodeObj.transform.position, nodeObj.gameObject, 0, 0);
                
                if (!nodeName.Contains("Node")) {
                    ChessPiece c = createPiece(nodeObj.tag, n, nodeName);
                    boardPieces[aPos] = c;
                    aPos++;
                }
                bNodes[bPos] = n;
                bPos++;
            }
        }
        setup();
    }
    void Update()
    {
        
    }
}
