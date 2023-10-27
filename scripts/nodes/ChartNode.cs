using Godot;
using System;
using System.Text;

public partial class ChartNode : Node2D
{

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void Set(NodeUI nodeUI) {

        string text;

        ColorRect colorRect = GetNode<Node2D>("BackGround").GetNode<ColorRect>("ColorRect");
        Position = nodeUI.BackGroundPosition*Config.ChartSize;
        Scale = nodeUI.BackGroundScale*5;

        colorRect.Set("size", nodeUI.BackGroundSize*Config.ChartSize);
        colorRect.Set("color", nodeUI.BackGroundColor);

        Label label = GetNode<Node2D>("OfficialName").GetNode<Label>("Label");
        label.Set("size", nodeUI.TextSize*Config.ChartSize);
        label.Set("color", nodeUI.TextColor);

        if (nodeUI.TextDirection == Config.TextDirection.Horizontal)
        {
            text = nodeUI.Text;
        }
        else {
            text = HorizontalToVertical(nodeUI.Text);
        }

        label.Set("text", text);
    }

    private string HorizontalToVertical(string text) {
        StringBuilder output = new();

        foreach (char c in text)
        {
            if (IsChineseCharacter(c))
            {
                output.Append(c);
                output.AppendLine();
            }
            else
            {
                output.Append(c);
            }
        }
        return output.ToString();
    }

    private static bool IsChineseCharacter(char c)
    {
        // Chinese characters have Unicode range from 0x4E00 to 0x9FFF
        return c >= 0x4E00 && c <= 0x9FFF;
    }
}
