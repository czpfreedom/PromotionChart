using Godot;
using System;
using System.Collections.Generic;

public partial class InitScene : Node2D
{
    [Export]
    public PackedScene MainScene;
    [Export]
    public PackedScene GameScene;

    Data data;
    Node2D SelectNodeOne ;
    Node2D SelectNodeSecond;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		data = GetNode<Data>("/root/Data");
        SelectNodeOne = GetNode<Node2D>("SelectNodeOne");
        SelectNodeSecond = GetNode<Node2D>("SelectNodeSecond");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

    }

	public void OnSelectNodeOneConfirmButtonPressed() {

        for (int i = 0; i < 4;)
        {
            i++;
            Node2D teamNode = SelectNodeSecond.GetNode<Node2D>("Team" + i);

            for (int j = 0; j < 3;)
            {
                j++;
                Node2D playerNode = teamNode.GetNode<Node2D>("Player" + i + j);

                playerNode.Hide();
            }
            teamNode.Hide();
        }

        data.teamNum = int.Parse(SelectNodeOne.GetNode<Node2D>("TeamNumText").GetNode<LineEdit>("LineEdit").Text);
        data.playerNumPerTeam = int.Parse(SelectNodeOne.GetNode<Node2D>("PlayerNumText").GetNode<LineEdit>("LineEdit").Text);
        data.memberNumPerPlayer = int.Parse(SelectNodeOne.GetNode<Node2D>("MemberNumText").GetNode<LineEdit>("LineEdit").Text);
        data.initMoney = int.Parse(SelectNodeOne.GetNode<Node2D>("InitMoney").GetNode<LineEdit>("LineEdit").Text);

		for (int i = 0; i < data.teamNum; ) {
			i++;
			Node2D teamNode = SelectNodeSecond.GetNode<Node2D>("Team" + i);
			teamNode.Show();
			for (int j = 0; j < data.playerNumPerTeam;) {
                j++;
				Node2D playerNode = teamNode.GetNode<Node2D>("Player"+i+j);
                playerNode.Show();
            }
        }

    }

    public void OnSelectNodeSecondConfirmButtonPressed() {
        data.playerName = new List<string>();
        data.playerColor = new List<string>();
        for (int i = 0; i < data.teamNum;) {
            i++;
            Node2D teamNode = SelectNodeSecond.GetNode<Node2D>("Team" + i);
            for (int j = 0; j < data.playerNumPerTeam;)
            {
                j++;
                Node2D playerNode = teamNode.GetNode<Node2D>("Player" + i + j);
                string text = playerNode.GetNode<Node2D>("Name").GetNode<LineEdit>("LineEdit").Text;
                data.playerName.Add(text);
            }
        }
    }

    public void OnReturnMainButtonPressed() {
        GetTree().ChangeSceneToPacked(MainScene);
    }

    public void OnStartGameButtonPressed() {
        GetTree().ChangeSceneToPacked(GameScene);
    }
}
