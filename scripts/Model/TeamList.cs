using System.Collections;
using System.Collections.Generic;
using System;


public class TeamList 
{
    List<Team> list;

    public List<Team> List { get => list; set => list = value; }

    public TeamList() { 
        
    }

    public TeamList(int teamNum, int playerNum) {
        this.list = new List<Team>();
        for (int i = 0; i < teamNum; i++) { 
            Team team = new Team(playerNum);
            this.List.Add(team);
        }
    }
}
