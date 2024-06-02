using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ChessPiece
{
    private int moveSpaces = 1;
    private int[,] setLegalPaths = {{1, 0}, {0, 1}, {-1, 0}, {0, 1}};

    public Cannon(BoardNode node, string dName, string pColor) : base(node, dName, pColor) {
        base.movablePaths = setLegalPaths;
    }
}
