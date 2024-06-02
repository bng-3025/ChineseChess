using System;

public class Player
{
    private string pType;
    private int timeLeft;
    private int moveTimeLeft;
    private int wins = 0;

    public Player(string t, int startTime, int startMoveTime) {
        pType = t;
        timeLeft = startTime;
        moveTimeLeft = startMoveTime;
    }

    public void addWin() {
        wins++;
    }
    
    public string getPlayerType() {
        return pType;
    }
    public int getTimeLeft() {
        return timeLeft;
    }

    public int getMoveTimeLeft() {
        return moveTimeLeft;
    }
    public int getWins() {
        return wins;
    }
}
