using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class OfficialPositionProbability
{
    List<OfficialPosition> nextOfficialPosition;
    List<float> probability;

    public List<OfficialPosition> NextOfficialPosition { get => nextOfficialPosition; set => nextOfficialPosition = value; }
    public List<float> Probability { get => probability; set => probability = value; }

    public void Print() {
        GD.Print("num:"+ nextOfficialPosition .Count+ "\n");
        for (int i = 0; i < nextOfficialPosition.Count; i++) {
            GD.Print("nextOfficialPosition[" + i + "]:" + nextOfficialPosition[i].Name + "\n");
            GD.Print("probability[" + i + "]:" + probability[i]+"\n");
        }
    }

    public OfficialPositionProbability() {
        nextOfficialPosition = new List<OfficialPosition> { };
        probability = new List<float> { };
    }
}
