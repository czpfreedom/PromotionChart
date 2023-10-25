using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class Member 
{
    Player belongPlayer;
    OfficialPosition officialPosition;
    int id;
    string name;
    public Player BelongPlayer { get => belongPlayer; set => belongPlayer = value; }
    public OfficialPosition OfficialPosition { get => officialPosition; set => officialPosition = value; }
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }

    public void SetOriginal(OfficialPositionList officialPositionList) {
        this.officialPosition = officialPositionList.FindOfficialPositionByName("BaiXing");
    }
}
