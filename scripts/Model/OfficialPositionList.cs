using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class OfficialPositionList
{

    List<OfficialPosition> list;

    public List<OfficialPosition> List { get => list; set => list = value; }

    public OfficialPosition FindOfficialPositionByName(string name) {
        //GD.Print("!!!"+name);
        for (int indexer = 0; indexer < list.Count; indexer++)
        {
            if (list[indexer].Name.Equals(name))
            {
                //GD.Print(indexer+":"+list[indexer].Name);
                return List[indexer];
            }
            //GD.Print(indexer);
        }
        return null;
    }

}
