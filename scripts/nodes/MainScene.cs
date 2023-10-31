using Godot;
using System;

public partial class MainScene : Node2D
{

    [Export]
    public PackedScene InitScene;
    [Export]
    public PackedScene GameScene;

    Button buttonConfirm;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //GetTree().ChangeSceneToPacked(InitScene);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void OnStartButtonPressed() {
        GetTree().ChangeSceneToPacked(GameScene);
    }

    public void OnLoadButtonPressed() {

    }

    public void OnConfigButtonPressed() {
        GetTree().ChangeSceneToPacked(InitScene);
    }
}
