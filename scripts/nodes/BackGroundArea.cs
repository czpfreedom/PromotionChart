using Godot;
using System;

public partial class BackGroundArea : Area2D
{
	public void Start(Vector2 pos) { 
		
	}

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	/*
	public void OnMouseEntered() {
		GD.Print("Enter");
	}
	*/

	public void OnColorRectMouseEntered() {
		GD.Print("Enter");
	}

}
