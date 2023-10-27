using Godot;
using System;

public partial class NodeUI
{
    public Vector2 BackGroundSize=new();

    public Vector2 BackGroundPosition=new();

    public Vector2 BackGroundScale = new();

    public string BackGroundColor = "#000000";

    public string BackGroundPressedColor = "#000000";

    public Vector2 TextSize = new();

    public Vector2 TextPosition = new();

    public Vector2 TextScale = new();

    public string TextColor ="#000000";

    public string Text = string.Empty;

    public Config.TextDirection TextDirection = new();

    public void Print() {
        GD.Print("PositionBackGroundSize:"+ BackGroundSize+"\n");
        GD.Print("PositionBackGroundPosition:"+ BackGroundPosition+"\n");
        GD.Print("PositionBackGroundScale:"+ BackGroundScale+"\n");
        GD.Print("PositionBackGroundColor:"+ BackGroundColor+"\n");
        GD.Print("PositionTextSize:"+ TextSize+"\n");
        GD.Print("PositionTextPosition:"+ TextPosition+"\n"); 
        GD.Print("PositionTextScale:"+ TextScale+"\n");
        GD.Print("PositionTextColor:"+ TextColor+"\n");
        GD.Print("PositionText:"+ Text+"\n");
        GD.Print("textDirection:"+ TextDirection.ToString()+"\n");
    }
}
