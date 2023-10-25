using Godot;
using System;
using System.Collections.Generic;

public class Config
{
    public enum PauseState { Start, OnGoing, Pause, End};

    public enum TextDirection { Horizontal, Vertical };


    // 每个玩家的的流程都是：选择一个member -》摇骰子 -》 棋子移动，计算结果
    public enum RoundState { ChooseAMember, RollDice, MoveMentAndOtherResult};

    int playermaxnum;
    int membermaxnum;

    float maxTime;
    int initMoney;
    int loseNeedMoney;

    List<Color> colors;

    public static int ChartSize = 13;

    public int Playermaxnum { get => playermaxnum; set => playermaxnum = value; }
    public int Membermaxnum { get => membermaxnum; set => membermaxnum = value; }
    public float MaxTime { get => maxTime; set => maxTime = value; }
    public int InitMoney { get => initMoney; set => initMoney = value; }
    public int LoseNeedMoney { get => loseNeedMoney; set => loseNeedMoney = value; }
    public List<Color> Colors { get => colors; set => colors = value; }
}
