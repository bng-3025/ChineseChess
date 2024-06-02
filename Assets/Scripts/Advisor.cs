using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor : ChessPiece
{
    private int moveSpaces = 1;
    private int[,] setLegalPaths = {{1, 0}, {0, 1}, {-1, 0}, {0, 1}};

    public Advisor(BoardNode node, string dName, string pColor) : base(node, dName, pColor) {
        base.movablePaths = setLegalPaths;
    }
}
