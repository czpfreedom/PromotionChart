using Godot;
using System;
using System.Collections.Generic;

public partial class ColorList 
{
    List<string> values = new();
    List<string> names = new();

    public List<string> Values { get => values; set => values = value; }
    public List<string> Names { get => names; set => names = value; }

    public void Print() {
        GD.Print("num:"+ values .Count+ "\n");
        for(int i=0;i<values.Count;i++) {
            GD.Print("color[" + i + "]:" + names[i] + ",value:" + values[i]+"\n");
        }
    }
    public string FindValueByName(string name) {
        for (int i = 0; i < values.Count; i++) {
            if (name == this.names[i])
                return values[i];
        }
        return string.Empty;
    }

}
