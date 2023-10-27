using Godot;
using System;

public partial class OfficialPositionNode : ChartNode
{
	public int enter ;
	public int pressTimeSign ;
	public Timer pressTimer;
	public OfficialPosition OfficialPosition;

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
					if (GetParent<ChartSceneNode>().GetParent<GameScene>().gameState.PresentPlayer.FindMemberFromOfficialPosition(this.OfficialPosition)!=null) {
                        pressTimeSign = 0;
                        pressTimer.Start();
						if (GetParent<ChartSceneNode>().GetParent<GameScene>().PressedOfficialPositionNode != this)
						{
                            GetParent<ChartSceneNode>().GetParent<GameScene>().ReturnOriginFromPressedOfficialPositionNode = GetParent<ChartSceneNode>().GetParent<GameScene>().PressedOfficialPositionNode;
                            GetParent<ChartSceneNode>().GetParent<GameScene>().PressedOfficialPositionNode = this;
                        }
                    }

                }
            }
        }
    }

	public void OnLabelMouseEntered() {
		enter = 1;
    }

	public void OnLabelMouseExited() {
		enter = 0;
	}

	public void OnPressTimerTimeout() {
		pressTimeSign = 1;
	}

	public void SetColorPressed() {
        GetNode<Node2D>("BackGround").GetNode<ColorRect>("ColorRect").Set("color", OfficialPosition.PositionNodeUI.BackGroundPressedColor);
	}

    public void SetColorNotPressed()
    {
        GetNode<Node2D>("BackGround").GetNode<ColorRect>("ColorRect").Set("color", OfficialPosition.PositionNodeUI.BackGroundColor);
    }
}
