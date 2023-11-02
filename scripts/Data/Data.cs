using Godot;
using System.Collections.Generic;

public partial class Data : Node
{
    public int teamNum;
    public int playerNumPerTeam;
    public int memberNumPerPlayer;
    public int initMoney;

    public List<string> teamName = new List<string>();
    public List<string> playerName = new List<string>();
    public List<string> playerColor = new List<string>();

    public void SetNull() {
        teamName = new List<string>();
        playerName = new List<string>();
        playerColor = new List<string>();
    }


}