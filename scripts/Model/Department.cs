using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class Department
{
    string name;
    string chineseName;
    NodeUI nodeUI;

    public string Name { get => name; set => name = value; }
    public string ChineseName { get => chineseName; set => chineseName = value; }
    public NodeUI NodeUI { get => nodeUI; set => nodeUI = value; }

    public Department() {
        name = string.Empty;
        chineseName = string.Empty;
        NodeUI = new NodeUI();
    }

    public void Print() {
        GD.Print("name:"+name+"\n");
        GD.Print("chinesename:"+chineseName+"\n");
        nodeUI.Print();
    }
}
