using Godot;
using System;

public partial class Hud : CanvasLayer
{
	Label moneyLabel;
    Label diceLabel;
    Label stateLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		moneyLabel = (Label)GetNode<Label>("MoneyLabel");
		diceLabel = (Label)GetNode<Label>("DiceResult");
		stateLabel = (Label)GetNode<Label>("StateLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ShowMoneyLabel(string message) 
	{ 
		moneyLabel.Text = message;
	}

    public void ShowDiceLabel(string message)
    {
		diceLabel.Text = message;
    }

    public void ShowStateLabel(string message)
    {
		stateLabel.Text = message;
    }
}
