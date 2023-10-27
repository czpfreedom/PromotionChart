using Godot;
using System;

public partial class GameScene : Node2D
{

    public GameState gameState;
	private ChartSceneNode chartSceneNode;
    private Hud hudNode;
    private Timer StartTimer;

    public OfficialPositionNode PressedOfficialPositionNode;
    public OfficialPositionNode ReturnOriginFromPressedOfficialPositionNode;



    private ColorList colorList;
    private OfficialPositionList officialPositionList;
    private DepartmentList departmentList;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        colorList= new();
        ColorListMapper.LoadXML(colorList, "D:/godot/PromotionChart/resources/Color.xml");
        departmentList = new ();
        DepartmentMapper.LoadXML(departmentList, "D:/godot/PromotionChart/resources/Department.xml", colorList);
        officialPositionList = new ();
        OfficialPositionMapper.LoadXML(departmentList, officialPositionList, "D:/godot/PromotionChart/resources/OfficialPosition.xml", colorList);

        gameState = new();
		gameState.InitForTest(colorList,officialPositionList);
        chartSceneNode = (ChartSceneNode)GetNode<ChartSceneNode>("ChartScene");
        hudNode = (Hud)GetNode<Hud>("hud");
        StartTimer = (Timer)GetNode<Timer>("StartTimer");

        chartSceneNode.SetChartScenNode(colorList,departmentList,officialPositionList);

        StartTimer.Start();
        PressedOfficialPositionNode = null;
        ReturnOriginFromPressedOfficialPositionNode = null;
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
        PressedOfficialPositionNode?.SetColorPressed();
        ReturnOriginFromPressedOfficialPositionNode?.SetColorNotPressed();
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

    public void SetPressedOfficialPositionNode(OfficialPositionNode officialPositionNodeNeedToBeSet) {
        if (gameState.PresentPlayer.FindMemberFromOfficialPosition(officialPositionNodeNeedToBeSet.OfficialPosition) != null)
        {
            officialPositionNodeNeedToBeSet.pressTimeSign = 0;
            officialPositionNodeNeedToBeSet.pressTimer.Start();
            if (PressedOfficialPositionNode != officialPositionNodeNeedToBeSet)
            {
                ReturnOriginFromPressedOfficialPositionNode = PressedOfficialPositionNode;
                PressedOfficialPositionNode = officialPositionNodeNeedToBeSet;
            }
        }
    }
}
