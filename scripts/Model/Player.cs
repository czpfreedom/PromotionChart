using System.Collections;
using System.Collections.Generic;
using Godot;
using System;

public class Player
{
    string name;
    int money;
    List<Member> memberList;
    String color;

    int isEffective;

    public string Name { get => name; set => name = value; }
    public int Money { get => money; set => money = value; }
    public List<Member> MemberList { get => memberList; set => memberList = value; }
    public String Color { get => color; set => color = value; }
    public int IsEffective { get => isEffective; set => isEffective = value; }

    public void SetOriginal(OfficialPositionList officialPositionList)
    {
        for (int i = 0; i < memberList.Count; i++)
        {
            memberList[i].SetOriginal(officialPositionList);
        }
    }

    public Player()
    {

    }

    public Player(int num, string name, int money, String color)
    {
        this.name = name;
        this.color = color;
        this.money = money;
        this.memberList = new List<Member>();
        for (int i = 0; i < num; i++)
        {
            Member member = new();
            this.memberList.Add(member);
        }
        this.IsEffective = 1;
    }

    /*
    public int IsContainOfficialPosition(OfficialPosition officialposition)
    {
        for (int i = 0; i < memberList.Count; i++)
        {
            if (memberList[i].OfficialPosition == officialposition)
            {
                return 1;
            }
        }
        return 0;
    }
    */

    public Member FindMemberFromOfficialPosition(OfficialPosition officialposition)
    {
        for (int i = 0; i < memberList.Count; i++)
        {
            if (memberList[i].OfficialPosition == officialposition)
            {
                return memberList[i];
            }
        }
        return null;
    }
}