using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class OfficialPositionProbability
{
    int num;
    List<OfficialPosition> nextOfficialPosition;
    List<float> probability;

    public int Num { get => num; set => num = value; }
    public List<OfficialPosition> NextOfficialPosition { get => nextOfficialPosition; set => nextOfficialPosition = value; }
    public List<float> Probability { get => probability; set => probability = value; }

    public void Print() {
        GD.Print("num:"+num+"\n");
        for (int i = 0; i < num; i++) {
            GD.Print("nextOfficialPosition[" + i + "]:" + nextOfficialPosition[i].Name + "\n");
            GD.Print("probability[" + i + "]:" + probability[i]+"\n");
        }
    }
}
