using Godot;
using System;

public partial class Test : Node2D
{
	[Export]
	public PackedScene PackedScene;

	public ColorList colorList = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        ColorListMapper.LoadXML(colorList,"D:/godot/PromotionChart/resources/Color.xml");
		colorList.Print();

		for (int i = 0; i < colorList.Values.Count; i++)
		{
			DepartmentNode department = (DepartmentNode)PackedScene.Instantiate();
			department.Position = new Vector2(100, 50 + i * 30);
			ColorRect color = department.GetNode<Node2D>("BackGround").GetNode<ColorRect>("ColorRect");
			color.Set("color", colorList.FindValueByName(colorList.Names[i]));
			AddChild(department);
		}

		GD.Print(colorList.FindValueByName("yellow"));

		
		/*
		string stringOrigin = "1,1";

        string[] parts = stringOrigin.Split(',');
        float x = float.Parse(parts[0]);
        float y = float.Parse(parts[1]);
        Vector2 vector = new Vector2(x, y);
		GD.Print(vector);
		*/
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
