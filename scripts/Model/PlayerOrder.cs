using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class PlayerOrder 
{
    List<Player> order;

    public List<Player> Order { get => order; set => order = value; }

    public PlayerOrder(int num) {
        this.Order = new List<Player>();   
        for (int i = 0; i < num; i++)
        {
            Player player = new Player();
            order.Add(player);
        }
    }
}
