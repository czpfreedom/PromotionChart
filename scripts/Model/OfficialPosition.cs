using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class OfficialPosition
{

    // 官职id
    string id;

    // 官职名称
    string name;

    // 官职所属部门

    Department department;

    // 官职在所属部门的级别
    int level;

    // 官职的品阶
    string grade;

    // 描述
    string description;

    // 是否是最高级别官员
    bool isMaster;

    // 下一个官职
    OfficialPositionProbability nextOfficialPositionProbability;

    // 官职UI

    NodeUI positionNodeUI;

    // 品阶UI

    NodeUI gradeNodeUI;

    public string Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int Level { get => level; set => level = value; }
    public string Grade { get => grade; set => grade = value; }
    public string Description { get => description; set => description = value; }
    public bool IsMaster { get => isMaster; set => isMaster = value; }
    public OfficialPositionProbability NextOfficialPositionProbability { get => nextOfficialPositionProbability; set => nextOfficialPositionProbability = value; }
    public Department Department { get => department; set => department = value; }
    public NodeUI PositionNodeUI { get => positionNodeUI; set => positionNodeUI = value; }
    public NodeUI GradeNodeUI { get => gradeNodeUI; set => gradeNodeUI = value; }

    public void Print() { 
        GD.Print("Id:"+id+"\n");
        GD.Print("Name:" + name + "\n");
        GD.Print("Level:" + level + "\n");
        GD.Print("Grade:" + grade + "\n");
        GD.Print("Description:" + description + "\n");
        GD.Print("IsMaster:" + isMaster + "\n");
        GD.Print("nextOfficialPositionProbability:" +"\n");
        nextOfficialPositionProbability.Print();
        GD.Print("department:" +"\n");
        department.Print();
        GD.Print("positionNodeUI:" + "\n");
        positionNodeUI.Print();
        GD.Print("gradeNodeUI:" + "\n");
        gradeNodeUI.Print();
    }
}
