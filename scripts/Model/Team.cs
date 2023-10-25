using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class Team 
{
    public string Name;
    List<Player> playerList;
    public List<Player> PlayerList { get => playerList; set => playerList = value; }

    public Team() { 
    
    }

    public Team(int num)
    {
        this.playerList = new List<Player>();
        for (int i = 0; i < num; i++)
        {
            Player player = new Player();
            this.playerList.Add(player);
        }
    }
}
