using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Collections;
using UnityEngine;

public class BoardNode
{
    private Vector3 coords;
    private ChessPiece occupier;
    private GameObject assignedObj;
    int row;
    int col;

    public BoardNode(Vector3 co, GameObject obj, int r, int c) {
        coords = co;
        assignedObj = obj;
        row = r;
        col = c;
    }

    public ChessPiece getOccupier() {
        return occupier;
    }

    public void setOccupier(ChessPiece o) {
        occupier = o;
    }

    public Boolean isOccupied() {
        return !(occupier == null);
    }

    public Vector3 getCoords() {
        return coords;
    }

    public int getRow() {
        return row;
    }
    
    public int getCol() {
        return col;
    }

    public GameObject getAssignedObj() {
        return assignedObj;
    }

    public void setRow(int r) {
        row = r;
    }
    
    public void setCol(int c) {
        col = c;
    }
}
