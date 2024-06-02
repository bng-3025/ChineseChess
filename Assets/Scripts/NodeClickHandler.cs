using UnityEngine;

public class NodeClickHandler : MonoBehaviour
{
    private void setPieceColor(ChessPiece c, Color targetColor) {
        c.getAssignedObj().GetComponent<SpriteRenderer>().color = targetColor;
    }

    private void movePiece(BoardNode b) {
        ChessRunner.pieceSelected.move(b);
        ChessRunner.isSelecting = false;
        setPieceColor(ChessRunner.pieceSelected, Color.white);
        ChessRunner.pieceSelected = null;
        ChessRunner.switchPlayers();
    }

    void OnMouseDown() {
        BoardNode targetNode = ChessRunner.getNodeObj(gameObject);

        if (targetNode != null) {
            foreach (BoardNode b in ChessRunner.bNodes) {

                if ((targetNode.getCoords() - b.getCoords()).magnitude <= 0.1f) {
                    if (b.getOccupier() != null) {
                        ChessPiece cObj = b.getOccupier();
                            
                        if (cObj.sameColor(ChessRunner.currentPlayer.getPlayerType())) {
                            if (ChessRunner.pieceSelected != null) {
                                setPieceColor(cObj, Color.white);
                            }
                            ChessRunner.isSelecting = true;
                            ChessRunner.pieceSelected = cObj;
                            setPieceColor(cObj, Color.red);
                        }
                        else {
                            if (ChessRunner.pieceSelected != null) {
                                b.getOccupier().getAssignedObj().transform.position = new Vector3(9999.0f, 9999.0f, 9999.0f);
                                movePiece(b);
                                
                            }
                            else {
                                ChessRunner.isSelecting = false;
                                setPieceColor(cObj, Color.white);
                                ChessRunner.pieceSelected = null;
                            }
                        }
                    }
                    else if (ChessRunner.pieceSelected != null) {
                        movePiece(b);
                    }
                }
            }
        }
    }
}
