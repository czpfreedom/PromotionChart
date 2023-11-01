using Godot;
using System;

public partial class GameState 
{
    private TeamList teamList;
    private PlayerOrder playerOrder;

    private int round;
    private int turnInRound;
    private Player presentPlayer;
    public Member ChosenMember;

    private Config.RoundState roundState;

    private Config.PauseState pauseState;

    private Dice dice;


    public TeamList TeamList { get => teamList; set => teamList = value; }
    public PlayerOrder PlayerOrder { get => playerOrder; set => playerOrder = value; }
    public int Round { get => round; set => round = value; }
    public Player PresentPlayer { get => presentPlayer; set => presentPlayer = value; }
    public Config.RoundState RoundState { get => roundState; set => roundState = value; }
    public Config.PauseState PauseState { get => pauseState; set => pauseState = value; }
    public int TurnInRound { get => turnInRound; set => turnInRound = value; }
    public Dice Dice { get => dice; set => dice = value; }

    public void InitForTest(ColorList colorList, OfficialPositionList officialPositionList, Dice dice) {
        teamList = new TeamList(3,2);
        teamList.List[0].Name = "红队";
        teamList.List[1].Name = "绿队";
        teamList.List[2].Name = "蓝队";
        teamList.List[0].PlayerList[0] = new Player(3,"张三", 100, colorList.FindValueByName("Red"));
        teamList.List[0].PlayerList[1] = new Player(3,"李四", 100, colorList.FindValueByName("Orange"));
        teamList.List[1].PlayerList[0] = new Player(3,"王五", 100, colorList.FindValueByName("Yellow"));
        teamList.List[1].PlayerList[1] = new Player(3,"赵六", 100, colorList.FindValueByName("Green"));
        teamList.List[2].PlayerList[0] = new Player(3,"孙七", 100, colorList.FindValueByName("Blue"));
        teamList.List[2].PlayerList[1] = new Player(3,"周八", 100, colorList.FindValueByName("Purple"));

        playerOrder = new PlayerOrder(6);
        playerOrder.Order[0] = teamList.List[0].PlayerList[0];
        playerOrder.Order[1] = teamList.List[0].PlayerList[1];
        playerOrder.Order[2] = teamList.List[1].PlayerList[0];
        playerOrder.Order[3] = teamList.List[1].PlayerList[1];
        playerOrder.Order[4] = teamList.List[2].PlayerList[0];
        playerOrder.Order[5] = teamList.List[2].PlayerList[1];

        round = 0;
        turnInRound = 0;

        presentPlayer = playerOrder.Order[0];

        roundState = Config.RoundState.ChooseAMember;

        pauseState = Config.PauseState.Start;

        for (int i = 0; i < teamList.List.Count; i++) {
            for (int j = 0; j < teamList.List[i].PlayerList.Count; j++) {
                for (int k = 0; k < teamList.List[i].PlayerList[j].MemberList.Count; k++) {
                    teamList.List[i].PlayerList[j].MemberList[k].OfficialPosition = officialPositionList.FindOfficialPositionByName("BaiXing");
                }
            }
        }
        this.dice = dice;
    }

    public void InitForData(Data data, ColorList colorList, OfficialPositionList officialPositionList, Dice dice) {
        teamList = new TeamList(data.teamNum, data.playerNumPerTeam);
        playerOrder = new PlayerOrder(data.teamNum* data.playerNumPerTeam);

        for (int i = 0; i < data.teamNum; i++ ) {
            teamList.List[i].Name = "队伍" + i;
            for (int j = 0; j < data.playerNumPerTeam;j++) {
                teamList.List[i].PlayerList[j] = new Player(data.memberNumPerPlayer, data.playerName[i* data.playerNumPerTeam+j], data.initMoney, colorList.FindValueByName("Red"));
                PlayerOrder.Order[i * data.playerNumPerTeam + j] = teamList.List[i].PlayerList[j];
            }
        }

        round = 0;
        turnInRound = 0;

        presentPlayer = playerOrder.Order[0];

        roundState = Config.RoundState.ChooseAMember;

        pauseState = Config.PauseState.Start;

        for (int i = 0; i < teamList.List.Count; i++)
        {
            for (int j = 0; j < teamList.List[i].PlayerList.Count; j++)
            {
                for (int k = 0; k < teamList.List[i].PlayerList[j].MemberList.Count; k++)
                {
                    teamList.List[i].PlayerList[j].MemberList[k].OfficialPosition = officialPositionList.FindOfficialPositionByName("BaiXing");
                }
            }
        }
        this.dice = dice;
    }

    public String GetMoneyLabelMessage() {
        String message = "";

        for (int i = 0; i < teamList.List.Count; i++) {
            message += "队伍" + teamList.List[i].Name +":\n";
            for (int j = 0; j < teamList.List[i].PlayerList.Count; j++) {
                message += "成员" + teamList.List[i].PlayerList[j].Name + ":" + teamList.List[i].PlayerList[j].Money + "\n";

                // 这是个用来显示当前玩家数据的代码，正式代码中删除
                for (int k = 0; k < teamList.List[i].PlayerList[j].MemberList.Count; k++) {
                    message += teamList.List[i].PlayerList[j].MemberList[k].OfficialPosition.Chinesename + ",";
                }
                message += "\n";
            }
        }
        return message;
    }

    public String GetDiceMessage() {
        String message = "骰子的结果是:"+dice.State;


        return message;
    }

    public String GetStateLabelMessage()
    {
        String message = "";
        if (roundState == Config.RoundState.RollDice) {
            return "请玩家"+ presentPlayer.Name+"摇骰子";
        }
        if (roundState == Config.RoundState.ChooseAMember)
        {
            return "请玩家" + presentPlayer.Name + "选择成员";
        }
        if (roundState == Config.RoundState.MoveMentAndOtherResult)
        {
            return "查看结果中";
        }
        return message;
    }

    public void ConfirmButtonPressed(GameScene gameScene) {
        if (RoundState == Config.RoundState.ChooseAMember)
        {
            ChosenMember = PresentPlayer.FindMemberFromOfficialPosition(gameScene.PressedOfficialPositionNode.OfficialPosition);
            RoundState = Config.RoundState.RollDice;
        }
    }

    public void DiceButtonPressed(GameScene gameScene) {
        if (RoundState == Config.RoundState.RollDice)
        {
            ChosenMember.OfficialPosition = Dice.GetNextState(gameScene.officialPositionList, ChosenMember.OfficialPosition);
            RoundState = Config.RoundState.MoveMentAndOtherResult;
            UpdateMoney();
        }
    }

    public void UpdateNextPresentPlayer() {
        playerOrder.PresentOrder = (playerOrder.PresentOrder + 1) % (playerOrder.Order.Count);
        presentPlayer = playerOrder.Order[playerOrder.PresentOrder];
    }

    public void UpdateMoney() {
        //遍历，除了自身全部遍历一遍
        for (int i = 0; i < teamList.List.Count; i++) {
            for (int j = 0; j < teamList.List[i].PlayerList.Count; j++) {
                for (int k = 0; k < teamList.List[i].PlayerList[j].MemberList.Count; k++) {
                    if (teamList.List[i].PlayerList[j].MemberList[k] != ChosenMember) {
                        UpdateMoneyOnePlayerToAnother(presentPlayer, teamList.List[i].PlayerList[j], ChosenMember, teamList.List[i].PlayerList[j].MemberList[k]);
                    }
                }
            }
        }
    }

    // Alice是当前回合的官员，Bob是非当前回合的
    public static void UpdateMoneyOnePlayerToAnother(Player playerAlice, Player playerBob, Member memberAlice, Member memberBob)
    {
        //未中狀元者,與出任者,與未出任者,具送禮雙分
        if (memberAlice.OfficialPosition.Name == "ZhuangYuan") {
            if (memberBob.OfficialPosition.Name!= "ZhuangYuan") {
                playerAlice.Money -= 10;
                playerBob.Money += 10;
            }
        }

        //同衙門者,小與大送禮,後與先送禮,具一分
        if (memberAlice.OfficialPosition.Department.Name.Equals(memberBob.OfficialPosition.Department.Name)&&(memberAlice.OfficialPosition.Department.Name!= "WeiZuoGuan")) {
            GD.Print(memberAlice.OfficialPosition.Department.Name);
            if (memberAlice.OfficialPosition.Level <= memberBob.OfficialPosition.Level) {
                playerAlice.Money -= 5;
                playerBob.Money += 5;
            }

            if (memberAlice.OfficialPosition.Level > memberBob.OfficialPosition.Level)
            {
                playerAlice.Money += 5;
                playerBob.Money -= 5;
            }
        }
    }
}
