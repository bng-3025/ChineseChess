using System;
using UnityEngine;

public class ChessPiece
{
    protected BoardNode currentNode;
    protected BoardNode startingNode;
    protected GameObject assignedObj;
    protected string color;
    protected int[,] movablePaths;
    protected BoardNode[] movableNodes;

    public string displayName;

    public ChessPiece(BoardNode node, string dName, string pColor) {
        currentNode = node;
        startingNode = node;
        displayName = dName;
        color = pColor;
    }

    public Boolean sameColor(string c) {
        return c.Equals(color);
    }

    public void move(BoardNode targetNode) {
        currentNode.setOccupier(null);
        currentNode = targetNode;
        assignedObj.transform.position = targetNode.getCoords();
        currentNode.setOccupier(this);
        //updateMoveableNodes();
    }

    public void setObj(GameObject obj) {
        assignedObj = obj;
    }

    public BoardNode getAssignedNode() {
        return currentNode;
    }

    public BoardNode getStartingNode() {
        return startingNode;
    }

    public GameObject getAssignedObj() {
        return assignedObj;
    }

    public BoardNode[] getMovableNodes() {
        return movableNodes;
    }

    public string getColor() {
        return color;
    }
    
    public void updateMoveableNodes() {
        movableNodes = new BoardNode[movablePaths.Length];

        int currentRow = currentNode.getRow();
        int currentCol = currentNode.getCol();

        for (int i = 0; i < movablePaths.Length; i++) {
            int newRow = currentRow + movablePaths[i, 0];
            int newCol = currentCol + movablePaths[i, 1];

            if ((newRow >= 0 && newRow <= 10) && (newCol >= 0 && newCol <= 9)) {
                BoardNode legalNode = ChessRunner.getNodeObj(newRow, newCol);
                if (legalNode != null) {
                    movableNodes[i] = legalNode;
                }
            }
        }
    }
}
