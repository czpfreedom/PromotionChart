using Godot;
using System;

public partial class GameState 
{
    private TeamList teamList;
    private PlayerOrder playerOrder;

    private int round;
    private int turnInRound;
    private Player presentPlayer;

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

    public void InitForTest(ColorList colorList) { 
        teamList = new TeamList(3,2);
        teamList.List[0].Name = "红队";
        teamList.List[1].Name = "绿队";
        teamList.List[2].Name = "蓝队";
        teamList.List[0].PlayerList[0] = new Player(3,"zhangsan", 100, colorList.FindValueByName("Red"));
        teamList.List[0].PlayerList[1] = new Player(3,"lisi", 100, colorList.FindValueByName("Orange"));
        teamList.List[1].PlayerList[0] = new Player(3,"wangwu", 100, colorList.FindValueByName("Yellow"));
        teamList.List[1].PlayerList[1] = new Player(3,"zhaoliu", 100, colorList.FindValueByName("Green"));
        teamList.List[2].PlayerList[0] = new Player(3,"sunqi", 100, colorList.FindValueByName("Blue"));
        teamList.List[2].PlayerList[1] = new Player(3,"zhouba", 100, colorList.FindValueByName("Purple"));

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
    }

    public String GetMoneyLabelMessage() {
        String message = "";

        for (int i = 0; i < teamList.List.Count; i++) {
            message += "队伍" + teamList.List[i].Name +":\n";
            for (int j = 0; j < teamList.List[i].PlayerList.Count; j++) {
                message += "成员" + teamList.List[i].PlayerList[j].Name + ":" + teamList.List[i].PlayerList[j].Money + "\n";
            }
        }
        return message;
    }

    public String GetDiceMessage() {
        String message = "";


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
}
