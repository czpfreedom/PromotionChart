using Godot;
using System;

public partial class OfficialPositionNode : ChartNode
{
	int enter ;
	int pressTimeSign ;
	Timer pressTimer;
	public OfficialPosition OfficialPosition;

	GameState gameState;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pressTimer = (Timer)GetNode<Timer>("PressTimer");
        enter = 0;
		pressTimeSign = 1;

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (enter == 1) {
			if(pressTimeSign == 1){
                if (Input.IsActionPressed("mouse_left"))
                {
					pressTimeSign = 0;
                    pressTimer.Start();
					GetParent<ChartSceneNode>().GetParent<GameScene>().PressedOfficialPositionNode = this;
					GD.Print(this.Name);
                }
            }
        }
    }

	public void OnLabelMouseEntered() {
		enter = 1;
        GD.Print(enter);
    }

	public void OnLabelMouseExited() {
		enter = 0;
		GD.Print(enter);
	}

	public void OnPressTimerTimeout() {
		pressTimeSign = 1;
	}
}
