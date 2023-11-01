using Godot;
using System;

public partial class Game : Node2D
{
    [Export]
    public PackedScene MainScene;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        GetTree().ChangeSceneToPacked(MainScene);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
