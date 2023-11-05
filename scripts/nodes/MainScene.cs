using Godot;
using System;

public partial class MainScene : Node2D
{


	private PackedScene InitScene;
	private PackedScene GameScene;

	Button buttonConfirm;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnStartButtonPressed() {
		GameScene = (PackedScene)GD.Load("res://scenes/game_scene.tscn");
		GetTree().ChangeSceneToPacked(GameScene);
	}

	public void OnLoadButtonPressed() {

	}

	public void OnConfigButtonPressed() {
		InitScene = (PackedScene)GD.Load("res://scenes/init_scene.tscn");
		GetTree().ChangeSceneToPacked(InitScene);
	}
}
