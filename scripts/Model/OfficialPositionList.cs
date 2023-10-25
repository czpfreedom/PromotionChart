using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class OfficialPositionList
{
    int num;
    List<OfficialPosition> list;

    public int Num { get => num; set => num = value; }
    public List<OfficialPosition> List { get => list; set => list = value; }

    public OfficialPosition FindOfficialPositionByName(string name) {
        for (int indexer = 0; indexer < num; indexer++)
        {
            if (list[indexer].Name == name)
            {
                return list[indexer];
            }
        }
        return null;
    }

}
