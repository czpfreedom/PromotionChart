using Godot;
using System;

public partial class GameScene : Node2D
{
    private ColorList colorList;
    private GameState gameState;
	private ChartSceneNode chartSceneNode;
    private Hud hudNode;
    private Timer StartTimer;

    public OfficialPositionNode PressedOfficialPositionNode;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        colorList= new ColorList();
        ColorListMapper.LoadXML(colorList, "D:/godot/PromotionChart/resources/Color.xml");

        gameState = new GameState();
		gameState.InitForTest(colorList);
        chartSceneNode = (ChartSceneNode)GetNode<ChartSceneNode>("ChartScene");
        hudNode = (Hud)GetNode<Hud>("hud");
        StartTimer = (Timer)GetNode<Timer>("StartTimer");

        StartTimer.Start();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	

    
    public override void _Process(double delta)
	{
        if (gameState.PauseState == Config.PauseState.Start) {
            StartStateProcess();
        }

        if (gameState.PauseState == Config.PauseState.End)
        {
            EndStateProcess();
        }

        if (gameState.PauseState == Config.PauseState.Pause)
        {
            PauseStateProcess();
        }

        if (gameState.PauseState == Config.PauseState.OnGoing)
        {
            OngoingStateProcess();
        }
    }

    private void StartStateProcess() {
        hudNode.ShowStateLabel("游戏开始");
    }

    private void PauseStateProcess()
    {

    }

    private void EndStateProcess()
    {

    }

    private void OngoingStateProcess()
    {
        hudNode.ShowStateLabel(gameState.GetStateLabelMessage());
        hudNode.ShowMoneyLabel(gameState.GetMoneyLabelMessage());
        if (gameState.RoundState == Config.RoundState.ChooseAMember) {
            ChooseAMemberProcess();
        }

        if (gameState.RoundState == Config.RoundState.RollDice)
        {
            RollDiceProcess();
        }

        if (gameState.RoundState == Config.RoundState.MoveMentAndOtherResult)
        {
            MoveMentAndOtherResultProcess();
        }
    }

    public void OnStartTimerTimeout() {
        gameState.PauseState = Config.PauseState.OnGoing;
        gameState.RoundState = Config.RoundState.ChooseAMember;
    }

    public void OnChooseMemberTimerTimeout() {
        // 随机挑一个member
        gameState.RoundState = Config.RoundState.RollDice;
    }

    private void ChooseAMemberProcess() {
        
    }

    private void RollDiceProcess(){

    }

    private void MoveMentAndOtherResultProcess(){
    }
}
