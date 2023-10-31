using Godot;
using System;

public partial class InitScene : Node2D
{
	Data data;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		data = GetNode<Data>("/root/Data");
		Label label = GetNode<Label>("Text");
		label.Hide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

    }

	public void OnSelectNodeOneConfirmButtonPressed() {
		Node2D SelectNodeOne = GetNode<Node2D>("SelectNodeOne");
		data.teamNum = int.Parse(SelectNodeOne.GetNode<Node2D>("TeamNumText").GetNode<LineEdit>("LineEdit").Text);
        data.playerNumPerTeam = int.Parse(SelectNodeOne.GetNode<Node2D>("PlayerNumText").GetNode<LineEdit>("LineEdit").Text);
        data.memberNumPerPlayer = int.Parse(SelectNodeOne.GetNode<Node2D>("MemberNumText").GetNode<LineEdit>("LineEdit").Text);
        data.initMoney = int.Parse(SelectNodeOne.GetNode<Node2D>("InitMoney").GetNode<LineEdit>("LineEdit").Text);
        Label label = GetNode<Label>("Text");
        label.Show();

    }
}
